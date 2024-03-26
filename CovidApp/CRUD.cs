using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CovidApp
{
    public class CRUD
    {
        private Model1Container context = new Model1Container();
        private dynamic ConvertJToken(Type propertyType, JToken value)
        {
            if (propertyType == typeof(double) || propertyType == typeof(double?))
            {
                double doubleValue = (double)value;
                return doubleValue;
            }
            else if (propertyType == typeof(int) || propertyType == typeof(int?))
            {
                int intValue = Convert.ToInt32((double)value);
                return intValue;
            }
            else if (propertyType == typeof(long) || propertyType == typeof(long?))
            {
                long longValue = Convert.ToInt64((double)value);
                return longValue;
            }
            else if (propertyType == typeof(string))
            {
                string stringValue = (string)value;
                return stringValue;
            }
            else if (propertyType == typeof(DateTime))
            {
                string dateString = (string)value;
                DateTime dateTimeValue = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return dateTimeValue;
            }
            return value;
        }
        public void addData(ref Area area, Dictionary<string, JToken>[] dataDictionaries)
        {
            if (dataDictionaries == null)
                Console.WriteLine("There is no Data");

            foreach (var dataDictionary in dataDictionaries)
            {
                Data data = new Data();
                foreach (var kvp in dataDictionary)
                {
                    PropertyInfo propertyInfo = typeof(Data).GetProperty(kvp.Key);
                    Type propertyType = propertyInfo.PropertyType;
                    var value = ConvertJToken(propertyType, kvp.Value);
                    propertyInfo.SetValue(data, value);
                }
                area.Data.Add(data);
                context.DataSet.Add(data);
            }
            context.SaveChanges();
        }
        public void addArea(string iso_code, Dictionary<string, JToken> areaDictionary, Dictionary<string, JToken>[] dataDictionaries)
        {
            Area area = new Area();

            area.iso_code = iso_code;
            foreach (var kvp in areaDictionary)
            {
                PropertyInfo propertyInfo = typeof(Area).GetProperty(kvp.Key);
                Type propertyType = propertyInfo.PropertyType;
                var value = ConvertJToken(propertyType, kvp.Value);
                propertyInfo.SetValue(area, value);
            }

            addData(ref area, dataDictionaries);

            context.AreaSet.Add(area);
            context.SaveChanges();
        }
        public void DeleteData(DateTime endDate)
        {
            List<Area> areas = GetAreas();
            foreach (var area in areas)
            {
                Console.WriteLine($"iso_code: {area.iso_code}");

                List<Data> filteredData = area.Data.Where(d => d.date > endDate).ToList();
                foreach (var data in filteredData)
                {
                    //area.Data.Remove(data);
                    context.DataSet.Remove(data);
                }
                context.SaveChanges();
            }
        }
        public List<Data> FindDataByDates(List<Data> datas, DateTime[] dates)
        {
            List<Data> matchingData = datas.Where(d => dates.Contains(d.date)).ToList();
            return matchingData;
        }
        public Data FindDataByDate(List<Data> datas, DateTime date)
        {
            Data data = datas.FirstOrDefault(d => d.date == date);
            return data;
        }
        public List<Data> FilterDataBeforeDate(List<Data> datas, DateTime dateTime)
        {
            return datas.Where(data => data.date < dateTime).ToList();
        }
        public List<Area> AreasByISO(List<string> isoCodes, List<Area> areas)
        {
            List<Area> filteredAreas = isoCodes
                .Join(areas, iso => iso, area => area.iso_code, (iso, area) => area)
                .ToList();
            return filteredAreas;
        }
        //I retrieve the values of the entities for the fieldName field.
        public List<object> RetrieveFieldValues<T>(List<T> entities, string fieldName)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(fieldName);
            List<object> values = entities.Select(t => propertyInfo.GetValue(t)).ToList();
            return values;
        }
        //You retrieve the value of the entity for the fieldName field.
        public dynamic RetrieveFieldValue<T>(T entity, string fieldName)
        {
            var value = RetrieveFieldValues(new List<T> { entity}, fieldName)[0];
            return value;
        }
        //For each field in fieldNames, there corresponds a list of values of the entities for that field.
        public Dictionary<string, List<object>> RetrieveFields<T>(List<T> entities, string[] fieldNames)
        {
            Dictionary<string, List<object>> pairs = new Dictionary<string, List<object>>();
            foreach (string fieldname in fieldNames)
                pairs[fieldname] = RetrieveFieldValues(entities, fieldname);
            return pairs;
        }
        //The field names.
        public static string[] GetFieldNames(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            string[] fieldNames = new string[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                // Check for the format <FieldName>k__BackingField
                if (field.Name.EndsWith(">k__BackingField"))
                {
                    // Remove <, >, and "k__BackingField" from the name
                    string fieldName = field.Name.Substring(1, field.Name.IndexOf(">") - 1);
                    fieldNames[i] = fieldName;
                }
                else
                {
                    fieldNames[i] = field.Name;
                }
            }

            return fieldNames;
        }
        //For each field, there is a list corresponding to the values of the entities for that field.
        public Dictionary<string, List<object>> RetrieveAllFields<T>(List<T> entities)
        {
            string[] allFields = GetFieldNames(typeof(T));
            Dictionary<string, List<object>> dictionary = RetrieveFields(entities, allFields);
            return dictionary;
        }
        //You retrieve the value of the area for the fieldName field.
        public dynamic GetFieldFromArea(Area area, string fieldName)
        {
            return RetrieveFieldValue(area, fieldName);
        }
        //You retrieve the value of the data for the fieldName field.
        public dynamic GetFieldFromData(Data data, string fieldName)
        {
            return RetrieveFieldValue(data, fieldName);
        }
        //I retrieve the values of the area from the areas list for the fieldName field.
        public List<object> GetFieldValuesFromArea(List<Area> areas, string fieldName)
        {
            return RetrieveFieldValues(areas, fieldName);
        }
        //I retrieve the values of the data from the datas list for the fieldName field.
        public List<object> GetFieldValuesFromData(List<Data> datas, string fieldName)
        {
            return RetrieveFieldValues(datas, fieldName);
        }
        //For each field in fieldNames, I retrieve a list of values of the areas for that field.
        public Dictionary<string, List<object>> GetFieldsValuesFromArea(List<Area> areas, string[] fieldNames)
        {
            return RetrieveFields(areas, fieldNames);
        }
        //For each field in fieldNames, I retrieve a list of values of the datas for that field.
        public Dictionary<string, List<object>> GetFieldsValuesFromData(List<Data> datas, string[] fieldNames)
        {
            return RetrieveFields(datas, fieldNames);
        }
        //For each field of the Area class, there corresponds a list of values of the areas for that field.
        public Dictionary<string, List<object>> GetAllFieldsValuesFromArea(List<Area> areas)
        {
            return RetrieveAllFields(areas);
        }
        //For each field of the Data class, there corresponds a list of values of the datas for that field.
        public Dictionary<string, List<object>> GetAllFieldsValuesFromData(List<Data> datas)
        {
            return RetrieveAllFields(datas);
        }

        public List<DateTime> GetDatesFieldFromData(List<Data> data)
        {
            DateTime minDate = data.First().date;
            DateTime maxDate = data.Last().date;
            List<DateTime> dateList = GenerateDateList(minDate, maxDate);

            return dateList;
        }
        private List<DateTime> GenerateDateList(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }


        public List<Data> GetDataForArea(Area area)
        {
            List<Data> areaDataList = area.Data.ToList();
            List<Data> sortedDataList = areaDataList.OrderBy(data => data.date).ToList();
            return sortedDataList;
        }
        public Area GetArea(List<Area> areas, string iso_code)
        {
            Area area = areas.FirstOrDefault(a => a.iso_code == iso_code);
            return area;
        }
        public List<Area> GetAreas()
        {
            List<Area> areas = context.AreaSet.ToList();
            return areas;
        }
    }
}
