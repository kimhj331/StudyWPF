using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmApp.Helpers;
/// <summary>
/// DB관련 정보 -> Models
/// </summary>
namespace WpfMvvmApp.Models
{
    class Person
    {
        public string FirstName { get; set; } //table상 필드
        public string LastName { get; set; } //table상 필드

        string email;//table상 필드

        public string Email
        {
            get { return email; }
            set 
            {
                if (Commons.IsValidEmail(value))
                    email = value;
                else throw new Exception("Invalid Email");
            }
        }
  
        DateTime date; //table상 필드

        public DateTime Date
        {
            get { return date; }
            set 
            {
                var result = Commons.CalcAge(value); //나이
                if (result > 150 || result < 0)
                    throw new Exception("Invlid Age");
                else date = value; 
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date) //생성자
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public bool IsBirthDay //추가 속성 필드
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                        DateTime.Now.Day == Date.Day;
            }
        }
        public bool IsAdult //추가 필드
        {
            get { return Commons.CalcAge(Date) > 18; }
        }

        public string ChnZodiac
        {
            get{ return Commons.GetChineseZodiac(Date); }
        }
        public string Zodiac
        {
            get { return Commons.ClacZodiac(Date); }
        }
    }
}
