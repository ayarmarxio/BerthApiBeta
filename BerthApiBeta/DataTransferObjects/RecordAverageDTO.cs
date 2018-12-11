using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerthApiBeta.DataTransferObjects
{
    public class RecordAverageDTO
    {

        public int DayDate {get; set;}

        public int MonthDate { get; set; }

        public double BPSystolic { get; set; }

        public double BPDiastolic { get; set; }          
         

        public double BodyTemperature { get; set; }

        public double HeartBeatPerSecond { get; set; }

        public double Dust { get; set; }

        public double Sulphur { get; set; }

        public double Nitrogen { get; set; }

        public double Fluor { get; set; }

        public double CarbonMonoxide { get; set; }

        public double Ozone { get; set; }

        public double Temperature { get; set; }

        public double Pressure{ get; set; }

        public double Humidity { get; set; }

    }
}
