using ArduinoWPF.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArduinoWPF
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize(); //초기화
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>(); // object -> ViewModel
        }
    }
}
