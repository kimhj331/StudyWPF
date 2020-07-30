using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWPF.Models
{
    public class SensorDataModel
    {
        public class SensorData
        {
            public DateTime Date { get; set; }
            public ushort Value { get; set; }

            public SensorData(DateTime date, ushort value)
            {
                Date = date;
                Value = value;
            }
        }
        public string SP;

    }
}
