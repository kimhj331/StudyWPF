using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWPF.ViewModels
{
    public class HelpViewModel : Conductor<object>
    {
        public string proName;
        public string version;
        public string copyright;
        public string companyName;
        public string description;

        public string ProName
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public string Version
        {
            get
            {
                return "Version 1.0.0.0";
            }
        }
        public string Copyright
        {
            get
            {
                return "Copyright ⓒ Heeji.K";
            }
        }

        public string CompanyName
        {
            get
            {
                return "PKNU";
            }
        }

        public string Description
        {
            get
            {
                return "이 프로그램은 아두이노 조도센서를 사용하여 모니터링하고 그 정보를 MySQL DB에 저장하는 프로그램 입니다.";
            }

        }
    }
}
