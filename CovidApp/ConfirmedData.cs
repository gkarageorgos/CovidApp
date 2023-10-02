using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp
{
    public class ConfirmedData
    {
        public DateTime Date { get; set; }
        public float TotalConfirmed { get; set; }
        public ConfirmedData(DateTime date, int totalConfirmed)
        {
            this.Date = date;
            this.TotalConfirmed = totalConfirmed;
        }
    }
}
