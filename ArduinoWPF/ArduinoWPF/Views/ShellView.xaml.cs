using ArduinoWPF.ViewModels;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System.Dynamic;
using System.Windows;

namespace ArduinoWPF.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
        }

        IWindowManager manager = new WindowManager();
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic settings = new ExpandoObject();
            //새창 크기조절
            settings.Height = 300;
            settings.Width = 580;
            settings.SizeToContent = SizeToContent.Manual;

            manager.ShowWindow(new HelpViewModel(), null, settings);
        }
    }
}
