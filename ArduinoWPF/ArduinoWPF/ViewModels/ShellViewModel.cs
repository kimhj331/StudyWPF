using ArduinoWPF.Helpers;
using ArduinoWPF.Models;
using Caliburn.Micro;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Linq;
using System.Windows.Interop;
using System.Windows.Threading;
using static ArduinoWPF.Models.SensorDataModel;
using System.Windows.Media;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;
using System.ComponentModel;
using LiveCharts.Defaults;
using SeriesCollection = LiveCharts.SeriesCollection;
using LiveCharts.Wpf;
using System.Dynamic;
using ArduinoWPF.Views;

namespace ArduinoWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {

        public ShellViewModel()
        {
            InitControls();
        }

        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;

        List<SensorDataModel> photoDatas = new List<SensorDataModel>();

        Timer timer = new Timer();
        Random rand = new Random();

        public bool IsSimulation { get; set; }

        //전체 port리스트
        private BindableCollection<SensorDataModel> arduinoPort;

        private BindableCollection<SensorDataModel> ArduinoPort
        {
            get => arduinoPort;
            set
            {

            }
        }

        //선택된 하나의 port
        SensorDataModel selected_ArduinoPort;
        public SensorDataModel Selected_ArduinoPort
        {
            get => selected_ArduinoPort;
            set
            {
                selected_ArduinoPort = value;

                Date = value.Date;
                Value = value.Value;
                SerialProt = value.SerialProt;
                //NotifyOfPropertyChange(() => SelectedEmployee);
                //NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                NotifyOfPropertyChange(() => Date);
                //NotifyOfPropertyChange(() => CanSaveEmployee);
                //NotifyOfPropertyChange(() => CanDeleteEmployee);
            }
        }

        ushort value;
        public ushort Value
        {
            get => value;
            set
            {
                this.value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }

        string serialProt;
        public string SerialProt
        {
            get => serialProt;
            set
            {
                serialProt = value;
                NotifyOfPropertyChange(() => SerialProt);
            }
        }

        public List<ComboBoxItem> items { get; set; }

        private void InitControls()
        {
            //Date = DateTime.Parse(" ");
            Value = 0;
            public List<ComboBoxItem> items { get; set; }

        items = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { name = "red" },
                new ComboBoxItem() { name = "green" },
                new ComboBoxItem() { name = "blue" },
            };

            foreach (var item in SerialPort.GetPortNames())
            {
                CmbPort.Add(item)

}

            //PgbPhotoRegistor.Minimum = 0;
            //PgbPhotoRegistor.Maximum = maxPhotoVal;

            //BtnConnect.Enabled = BtnDisconnect.Enabled = false;
        }


        private void InitChart()
        {
            //Values.ChartAreas.Clear();
            //Values.ChartAreas.Add("sensor");
            //Values.ChartAreas["sensor"].AxisX.Minimum = 0;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.Maximum = xCount;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.Interval = xCount / 4;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.MajorGrid.LineColor = Colors.White;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.ScaleView.Zoomable = true;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            //ChtSensorValues.ChartAreas["sensor"].AxisX.ScrollBar.ButtonColor = Colors.LightSteelBlue;
            //ChtSensorValues.ChartAreas["sensor"].AxisY.Minimum = 0;
            //ChtSensorValues.ChartAreas["sensor"].AxisY.Maximum = maxPhotoVal + 1;
            //ChtSensorValues.ChartAreas["sensor"].AxisY.Interval = xCount;
            //ChtSensorValues.ChartAreas["sensor"].AxisY.MajorGrid.LineColor = Colors.White;
            //ChtSensorValues.ChartAreas["sensor"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            //ChtSensorValues.ChartAreas["sensor"].BackColor = Colors.DarkBlue;
            //ChtSensorValues.ChartAreas["sensor"].CursorX.AutoScroll = true;

            //ChtSensorValues.Series.Clear();
            //ChtSensorValues.Series.Add("PhotoRegistor");
            //ChtSensorValues.Series["PhotoRegistor"].ChartType = SeriesChartType.Line;
            //ChtSensorValues.Series["PhotoRegistor"].Color = Colors.LightGreen;
            //ChtSensorValues.Series["PhotoRegistor"].BorderWidth = 3;

            //if (ChtSensorValues.Legends.Count > 0)
            //    ChtSensorValues.Legends.RemoveAt(0);
        }
        public void LoadChart() //UserContrl FirstChildView
        {
            ActivateItem(new ChartViewModel());
        }

        
    }
}
