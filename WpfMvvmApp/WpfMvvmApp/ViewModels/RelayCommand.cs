using System;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
    //존재해야지 버튼클릭할때, 다른 이벤트 실행할 때 필요하다.
    public class RelayCommand<T> : ICommand //
    {
        //어떤 일을 발생시킴
        private readonly Action<T> excute;
        //TrueFalse값 리턴
        readonly Predicate<T> canExcute;

        public event EventHandler CanExecuteChanged 
        { //이벤트를 추가
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //기본 생성자
        public RelayCommand(Action<T> excute, Predicate<T> canExcute = null)
        {
            this.excute = excute ?? throw new ArgumentException(nameof(excute));
            this.canExcute = canExcute;
        }

        public RelayCommand(Action<T> excute) : this(excute, null) { }

        public bool CanExecute(object parameter) => canExcute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => excute((T)parameter);
    }
}
