using System.ComponentModel;

namespace WpfMvvmApp.ViewModels
{

    public class ViewModelBase : INotifyPropertyChanged //값이 바뀌면 알려줌
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //값이 바뀐 이후에 동작
        public void RaisePropertyChanged(string propertyName) //propertyName = firstName LastName Email
        {
            //PropertyChanged가 널이아니면 실행시켜라.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //.? == (!=null)

            /*
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            */
        }
    }
}
