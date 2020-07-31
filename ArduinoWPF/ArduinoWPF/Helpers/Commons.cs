using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWPF.Helpers
{
    public class Commons
    {
        public readonly string STRCONN = "Server=localhost;Port=3306;" +
             "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
    }
}
