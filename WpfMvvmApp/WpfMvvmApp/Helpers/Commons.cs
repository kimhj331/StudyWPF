using System;
using System.Web.Management;

namespace WpfMvvmApp.Helpers
{
    class Commons
    {
        public static bool IsValidEmail(string email)
        {
            string[] parts = email.Split('@');
            if (parts.Length != 2) return false;

            return (parts[1].Split('.').Length >= 2);
        }

        public static int CalcAge(DateTime date)
        {
            int middle;
            DateTime now = DateTime.Now;
            if (now.Month <= date.Month && now.Day < date.Day)
                middle = now.Year - date.Year - 1;
            //한국나이계산(생일 지난경우)
            else
                middle = now.Year - date.Year;
            return middle;
        }

        public static string GetChineseZodiac(DateTime date)
        {
            var value = date.Year % 12;
            switch (value)
            {
                case 0:
                    return "원숭이띠";
                case 1:
                    return "닭띠";
                case 2:
                    return "개띠";
                case 3:
                    return "돼지띠";
                case 4:
                    return "쥐띠";
                case 5:
                    return "소띠";
                case 6:
                    return "호랑이";
                case 7:
                    return "토끼띠";
                case 8:
                    return "용띠";
                case 9:
                    return "뱀띠";
                case 10:
                    return "말띠";
                case 11:
                    return "양띠";
                default:
                    return "";
            }
        }

        internal static string ClacZodiac(DateTime date)
        {
            string result;
            if (date <= DateTime.Parse(date.Year + "-01-20"))
                result = "염소자리";
            else if (date <= DateTime.Parse(date.Year + "-02-18"))
                result = "물병자리";
            else if (date <= DateTime.Parse(date.Year + "-03-20"))
                result = "물고기자리";
            else if (date <= DateTime.Parse(date.Year + "-04-20"))
                result = "양자리";
            else if(date<= DateTime.Parse(date.Year + "-05-20"))
                result = "황소자리";
            else if (date <= DateTime.Parse(date.Year + "-06-21"))
                result = "쌍둥이자리";
            else if (date <= DateTime.Parse(date.Year + "-07-22"))
                result = "게자리";
            else if (date <= DateTime.Parse(date.Year + "-08-22"))
                result = "사자자리";
            else if (date <= DateTime.Parse(date.Year + "-09-22"))
                result = "처녀자리";
            else if (date <= DateTime.Parse(date.Year + "-10-23"))
                result = "천칭자리";
            else if (date <= DateTime.Parse(date.Year + "-11-22"))
                result = "전갈자리";
            else
                result = "사수자리";
            return result;
        }
    }
}
