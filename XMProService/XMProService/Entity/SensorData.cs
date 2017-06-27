using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMProService.Entity
{
    public class SensorData
    {
        public Int64 ReadingID { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Luminosity { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
