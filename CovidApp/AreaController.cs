using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp
{
    public class AreaController
    {
        /*public int GetFieldFromData(Data data, string field)*/
        public int GetNewCasesFieldFromData(Data data)
        {
            int? new_cases = data.new_cases;
            if (new_cases == null)
                return 0;
            return (int)new_cases;
        }
        public Data FindDataByDate(List<Data> datas, DateTime date)
        {
            Data data = datas.FirstOrDefault(d => d.date == date);
            return data;
        }
        public List<DateTime> GetDatesFieldFromData(List<Data> data)
        {
            DateTime[] minAndMaxDates = GetMinAndMaxDates(data);
            DateTime minDate = minAndMaxDates[0];
            DateTime maxDate = minAndMaxDates[1];
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
        public DateTime[] GetMinAndMaxDates(List<Data> datas)
        {
            DateTime minDate = datas.Min(data => data.date);
            DateTime maxDate = datas.Max(data => data.date);
            Console.WriteLine(maxDate.ToString());
            return new DateTime[] { minDate, maxDate };
        }
        public List<Data> GetDataForArea(Area area)
        {
            return area.Data.ToList();
        }
        public Area GetArea(List<Area> areas, string iso_code)
        {
            Area area = areas.FirstOrDefault(a => a.iso_code == iso_code);
            return area;
        }
        public List<Area> GetAreas(Model1Container model1Container)
        {
            List<Area> areas = model1Container.AreaSet.ToList();
            return areas;
        }
    }
}
