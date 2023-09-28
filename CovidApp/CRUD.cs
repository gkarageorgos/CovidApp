using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class CRUD : Form
    {
        private Model1Container context = new Model1Container();

        internal static DateTime startDate = new DateTime(2020, 1, 1);
        internal static DateTime endDate = new DateTime(2023, 8, 31);

        public CRUD()
        {
            InitializeComponent();
        }
        public void jsonObjectToEntity<T>(ref T entity, JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties())
            {
                string field = property.Name;
                JToken value = property.Value;

                PropertyInfo propertyInfo = typeof(T).GetProperty(field);
                if (propertyInfo == null)
                {
                    if (entity is Area area)
                    {
                        JObject[] jsonObjects = value.ToObject<JObject[]>();
                        foreach (var dataJsonObject in jsonObjects)
                        {
                            Data data = new Data();
                            jsonObjectToEntity(ref data, dataJsonObject);
                            area.Data.Add(data);
                        }
                    }
                }
                else
                {
                    Type propertyType = propertyInfo.PropertyType;
                    if (propertyType == typeof(double) || propertyType == typeof(double?))
                    {
                        double doubleValue = (double)value;
                        propertyInfo.SetValue(entity, doubleValue);
                        Console.WriteLine($"{field}: {doubleValue}");
                    }
                    else if (propertyType == typeof(int) || propertyType == typeof(int?))
                    {
                        int intValue = Convert.ToInt32((double)value);
                        propertyInfo.SetValue(entity, intValue);
                        Console.WriteLine($"{field}: {intValue}");
                    }
                    else if (propertyType == typeof(long) || propertyType == typeof(long?))
                    {
                        long longValue = Convert.ToInt64((double)value);
                        propertyInfo.SetValue(entity, longValue);
                        Console.WriteLine($"{field}: {longValue}");
                    }
                    else if (propertyType == typeof(string))
                    {
                        string stringValue = (string)value;
                        propertyInfo.SetValue(entity, stringValue);
                        Console.WriteLine($"{field}: {stringValue}");
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        string dateString = (string)value;
                        DateTime dateTimeValue = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        propertyInfo.SetValue(entity, dateTimeValue);
                        Console.WriteLine($"{field}: {dateTimeValue}");
                    }
                }
            }
        }
        private void FillDB()
        {
            string jsonFilePath = "owid-covid-data.json";
            string json = File.ReadAllText(jsonFilePath);
            JObject jsonObject = JObject.Parse(json);

            foreach (var property in jsonObject.Properties())
            {
                string iso_code = property.Name;
                JObject areaData = (JObject)property.Value;

                Area area = new Area();
                area.iso_code = iso_code;
                Console.WriteLine($"iso_code: {iso_code}");

                jsonObjectToEntity(ref area, areaData);
                context.AreaSet.Add(area);
                context.SaveChanges();
            }
        }
        private void DeleteData()
        {
            List<Area> areas = context.AreaSet.ToList();
            foreach (var area in areas)
            {
                Console.WriteLine(area.Data.Count());
                List<Data> filteredData = area.Data.Where(d => d.date > endDate).ToList();
                foreach (var data in filteredData)
                {
                    context.DataSet.Remove(data);
                }
                context.SaveChanges();
                Console.WriteLine(area.Data.Count());
            }
        }
        private void UpdateData()
        {
            DeleteData();

            List<Area> areas = context.AreaSet.ToList();

            string jsonFilePath = "owid-covid-data.json";
            string json = File.ReadAllText(jsonFilePath);
            JObject jsonObject = JObject.Parse(json);

            int areaIndex = 0;
            foreach (var property in jsonObject.Properties())
            {
                Area area = areas[areaIndex];
                Console.WriteLine($"iso_code: {area.iso_code}");

                JObject areaData = (JObject)property.Value;
                JToken dataValue = areaData["data"];
                JObject[] jsonObjects = dataValue.ToObject<JObject[]>();
                foreach (var dataJsonObject in jsonObjects)
                {
                    string dateString = (string)dataJsonObject["date"];
                    DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    if (dateTime <= endDate)
                    {
                        continue;
                    }
                    Data data = new Data();

                    jsonObjectToEntity(ref data, dataJsonObject);

                    area.Data.Add(data);
                }
                areaIndex++;
                context.SaveChanges();
            }
        }
    }
}
