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
        public DateTime Date { get; set; }
        public ushort Value { get; set; }
        public string SerialProt { get; set; }

        public SensorDataModel(DateTime date, ushort value)
        {
            Date = date;
            Value = value;
        }

    }
}
