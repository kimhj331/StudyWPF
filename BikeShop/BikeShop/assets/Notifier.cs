using System.ComponentModel;

public class Notifier : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    //사용자가 데이터를 업데이트한경우
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
