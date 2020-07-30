using System;
using System.Windows;
using System.Windows.Input;
using WpfMvvmApp.Models;

namespace WpfMvvmApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        #region 멤버변수/속성영역
        string inFirstName;
        string inLastName;
        string inEmail;
        DateTime? inDate; //Nullable

        string outFirstName;
        string outLastName;
        string outEmail;
        string outDate;
        string outAdult;
        string outBirthday;
        string outChnZodiac; //200727 16:47 신규추가
        string outZodiac;

        public string InLastName 
        {
            get => inLastName;
            set
            {
                inLastName = value;
                RaisePropertyChanged("InLastName");//값이 바뀌었다는것을 알려줌.
            }
        }

        public string InFirstName
        {
            get => inFirstName;
            set
            {
                inFirstName = value;
                RaisePropertyChanged("InFirstName");//값이 바뀌었다는것을 알려줌.
            }
        }

        public string InEmail
        {
            get => inEmail;
            set
            {
                inEmail = value;
                RaisePropertyChanged("InEmail");//값이 바뀌었다는것을 알려줌.
            }
        }

        public DateTime? InDate
        {
            get => inDate;
            set
            {
                inDate = value;
                RaisePropertyChanged("InDate");//값이 바뀌었다는것을 알려줌.
            }
        }

        public string OutFirstName
        {
            get => outFirstName;
            set
            {
                outFirstName = value;
                RaisePropertyChanged("OutFirstName");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutLastName
        {
            get => outLastName;
            set
            {
                outLastName = value;
                RaisePropertyChanged("OutLastName");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutEmail
        {
            get => outEmail;
            set
            {
                outEmail = value;
                RaisePropertyChanged("OutEmail");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutDate
        {
            get => outDate;
            set
            {
                outDate = value;
                RaisePropertyChanged("OutDate");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutAdult
        {
            get => outAdult;
            set
            {
                outAdult = value;
                RaisePropertyChanged("OutAdult");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutBirthday
        {
            get => outBirthday;
            set
            {
                outBirthday = value;
                RaisePropertyChanged("OutBirthday");//값이 바뀌었다는것을 알려줌.
            }
        }
        public string OutChnZodiac
        {
            get => outChnZodiac;
            set
            {
                outChnZodiac = value;
                RaisePropertyChanged("OutChnZodiac");//200727 16:44 신규 추가: 띠추가
            }
        }
        public string OutZodiac
        {
            get => outZodiac;
            set
            {
                outZodiac = value;
                RaisePropertyChanged("OutZodiac");//200727 16:44 신규 추가: 띠추가
            }
        }

        #endregion

        ICommand clickCommand;
        
        public ICommand ClickCommand => clickCommand ?? (clickCommand = new RelayCommand<object>(
                o => Click(), o=>IsClick()));

        private void Click()
        {
            try
            {
                DateTime date = InDate ?? DateTime.Now;
                Person person = new Person(InFirstName, InLastName, InEmail, date);

                OutLastName = person.LastName;
                OutFirstName = person.FirstName;
                OutEmail = person.Email;
                OutDate = person.Date.ToShortDateString();
                OutAdult = $"{person.IsAdult}";
                OutBirthday = $"{person.IsBirthDay}";
                OutChnZodiac = person.ChnZodiac;
                OutZodiac = person.Zodiac;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
           
        }

        //값이 있을때 수행해야함.
        private bool IsClick()
        {
            return (!string.IsNullOrEmpty(InLastName) &&
               !string.IsNullOrEmpty(InFirstName) &&
               !string.IsNullOrEmpty(InEmail) &&
               !string.IsNullOrEmpty(InDate.ToString()));
        }
    }
}
