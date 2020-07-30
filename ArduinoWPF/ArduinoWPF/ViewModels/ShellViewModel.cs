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
using System.Windows.Interop;
using System.Windows.Threading;
using static ArduinoWPF.Models.SensorDataModel;

namespace ArduinoWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        #region 속성
        //public BindableCollection<EmployeesModel>
        public BindableCollection<SensorDataModel> PortName { get; set; }

        private void GetSerialPort()
        {
            PortName.Clear();

            foreach (var comport in SerialPort.GetPortNames())
            {
                PortName.Add(comport);
            }

            if (PortName.Count <= 0)
            {
                PortName.Add("찾을 수 없음");
            }
        }

        private void InitCombobox()
        {
            PortName.Add(new SensorDataModel { SerialPort.GetPortNames() });
            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                //읽을 값이 있는동안 계속
                while (reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    //바인더블 컬렉션
                    People.Add(temp);
                }
            }
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();
        }


        decimal LineNumber = 1;
       

        IntPtr WndProc(IntPtr hWnd, int nMsg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            UInt32 WM_DEVICECHANGE = 0x0219;
            UInt32 DBT_DEVTUP_VOLUME = 0x02;
            UInt32 DBT_DEVICEARRIVAL = 0x8000;
            UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

            //디바이스 연결시
            if ((nMsg == WM_DEVICECHANGE) && (wParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                int devType = Marshal.ReadInt32(lParam, 4);

                if (devType == DBT_DEVTUP_VOLUME)
                {
                    GetSerialPort();
                }
            }

            //디바이스 연결 해제시...
            if ((nMsg == WM_DEVICECHANGE) && (wParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))
            {
                int devType = Marshal.ReadInt32(lParam, 4);
                if (devType == DBT_DEVTUP_VOLUME)
                {
                    GetSerialPort();
                }
            }

            return IntPtr.Zero;
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    WindowInteropHelper helper = new WindowInteropHelper(this);
        //    HwndSource source = HwndSource.FromHwnd(helper.Handle);
        //    source.AddHook(new HwndSourceHook(this.WndProc));

        //    SP.DataReceived += new SerialDataReceivedEventHandler(SP_DataReceived);
        //}

        //private void SP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Dispatcher.Invoke(DispatcherPriority.Normal, new System.Action(delegate
        //    {
        //        string str = SP.ReadLine();
        //        textBox1.AppendText("[" + LineNumber++.ToString() + "] : " + str);
        //        textBox1.ScrollToEnd();
        //    }));
        //}

        //private void btnPortSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    GetSerialPort();
        //}

        private void GetSerialPort()
        {
            SP.Clear();
            foreach (string comport in SerialPort.GetPortNames())
            {
                SP.Add(comport);
            }

            if (SP.Count <= 0)
            {
                SP.Add("찾을 수 없음");
            }
        }


        ////private SerialPort arduSerialPort = new SerialPort();

        ////private short xCount = 200;
        ////private short maxPhotoVal = 1023;
        ////List<SensorData> photoDatas = new List<SensorData>();

        ////string strConnString = "Server=localhost;Port=3306;" +
        ////    "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";

        ////public bool IsSimulation { get; set; }

        ////Timer timer = new Timer();
        ////Random rand = new Random();

        ////ChartValues<float> values;

        ////public ChartValues<float> Values
        ////{
        ////    get => values;
        ////    set
        ////    {
        ////        values = value;
        ////        NotifyOfPropertyChange(() => Values);
        ////    }
        ////}
        ////#endregion
        ////#region 생성자

        ////public ShellViewModel()
        ////{
        ////    //InitializeComponent();
        ////    InitControls();
        ////    InitChart();

        ////    DisplayName = "Arduino Sensor Monitoring";

        ////    //Values = new ChartValues<float>
        ////    //{
        ////    //    3,
        ////    //    4,
        ////    //    6,
        ////    //    3,
        ////    //    2,
        ////    //    6
        ////    //};
        ////}
        //#endregion 

        //private void InitChart()
        //{
        ////    ChtSensorValues.ChartAreas.Clear();
        ////    ChtSensorValues.ChartAreas.Add("sensor");
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.Minimum = 0;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.Maximum = xCount;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.Interval = xCount / 4;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.MajorGrid.LineColor = Color.White;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.ScaleView.Zoomable = true;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisY.Minimum = 0;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisY.Maximum = maxPhotoVal + 1;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisY.Interval = xCount;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisY.MajorGrid.LineColor = Color.White;
        ////    ChtSensorValues.ChartAreas["sensor"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        ////    ChtSensorValues.ChartAreas["sensor"].BackColor = Color.DarkBlue;
        ////    ChtSensorValues.ChartAreas["sensor"].CursorX.AutoScroll = true;

        ////    ChtSensorValues.Series.Clear();
        ////    ChtSensorValues.Series.Add("PhotoRegistor");
        ////    ChtSensorValues.Series["PhotoRegistor"].ChartType = SeriesChartType.Line;
        ////    ChtSensorValues.Series["PhotoRegistor"].Color = Color.LightGreen;
        ////    ChtSensorValues.Series["PhotoRegistor"].BorderWidth = 3;

        ////    if (ChtSensorValues.Legends.Count > 0)
        ////        ChtSensorValues.Legends.RemoveAt(0);


        //}


        //private void InitControls()
        //{
            
        //    foreach (var item in SerialPort.GetPortNames())
        //    {
        //        CboSerialPort.Items.Add(item);
        //    }
        //    CboSerialPort.Text = "Select Port";

        //    //PgbPhotoRegistor.Minimum = 0;
        //    //PgbPhotoRegistor.Maximum = maxPhotoVal;

        //    //BtnConnect.Enabled = BtnDisconnect.Enabled = false;
        //}


        ////private void CboSerialPort_SelectedIndexChanged(object sender, System.EventArgs e)
        ////{
        ////    var portName = CboSerialPort.SelectedItem.ToString();
        ////    serial = new SerialPort(portName);
        ////    serial.DataReceived += Serial_DataReceived;

        ////    BtnConnect.Enabled = true;
        ////}

        ////private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        ////{
        ////    string sVal = serial.ReadLine();
        ////    this.BeginInvoke(new Action(delegate { DisplayValue(sVal); }));
        ////}

        ////private void DisplayValue(string sVal)
        ////{
        ////    try
        ////    {
        ////        ushort v = ushort.Parse(sVal);
        ////        if (v < 0 || v > maxPhotoVal)
        ////            return;

        ////        SensorData data = new SensorData(DateTime.Now, v);
        ////        photoDatas.Add(data);
        ////        InsertDataToDB(data);

        ////        TxtSensorCount.Text = photoDatas.Count.ToString();
        ////        PgbPhotoRegistor.Value = v;
        ////        LblPhotoRegistor.Text = v.ToString();

        ////        string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

        ////        RtbLog.AppendText($"{item}\n");
        ////        RtbLog.ScrollToCaret();

        ////        ChtSensorValues.Series[0].Points.Add(v);

        ////        ChtSensorValues.ChartAreas[0].AxisX.Minimum = 0;
        ////        ChtSensorValues.ChartAreas[0].AxisX.Maximum =
        ////            (photoDatas.Count >= xCount) ? photoDatas.Count : xCount;

        ////        if (photoDatas.Count > xCount)
        ////            ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(
        ////                photoDatas.Count - xCount, photoDatas.Count);
        ////        else
        ////            ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);

        ////        if (IsSimulation == false)
        ////            BtnPortValue.Text = $"{serial.PortName}\n{sVal}";
        ////        else
        ////            BtnPortValue.Text = $"{sVal}";
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        RtbLog.AppendText($"Error : {ex.Message}\n");
        ////        RtbLog.ScrollToCaret();
        ////    }
        ////}

        ////private void InsertDataToDB(SensorData data)
        ////{
        ////    string strQuery = "INSERT INTO sensordatatbl " +
        ////        " (Date, Value) " +
        ////        " VALUES " +
        ////        " (@Date, @Value) ";

        ////    using (MySqlConnection conn = new MySqlConnection(strConnString))
        ////    {
        ////        conn.Open();
        ////        MySqlCommand cmd = new MySqlCommand(strQuery, conn);
        ////        MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
        ////        {
        ////            Value = data.Date
        ////        };
        ////        cmd.Parameters.Add(paramDate);
        ////        MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
        ////        {
        ////            Value = data.Value
        ////        };
        ////        cmd.Parameters.Add(paramValue);
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////}

        ////private void BtnConnect_Click(object sender, EventArgs e)
        ////{
        ////    serial.Open();
        ////    LblConnectionTime.Text = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
        ////    BtnConnect.Enabled = false;
        ////    BtnDisconnect.Enabled = true;
        ////}

        ////private void BtnDisconnect_Click(object sender, EventArgs e)
        ////{
        ////    serial.Close();
        ////    BtnConnect.Enabled = true;
        ////    BtnDisconnect.Enabled = false;
        ////}

        ////private void BtnViewAll_Click(object sender, EventArgs e)
        ////{
        ////    ChtSensorValues.ChartAreas[0].AxisX.Minimum = 0;
        ////    ChtSensorValues.ChartAreas[0].AxisX.Maximum = photoDatas.Count;
        ////    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(0, photoDatas.Count);
        ////    ChtSensorValues.ChartAreas[0].AxisX.Interval = photoDatas.Count / 4;
        ////}

        ////private void BtnZoom_Click(object sender, EventArgs e)
        ////{
        ////    ChtSensorValues.ChartAreas[0].AxisX.Minimum = 0;
        ////    ChtSensorValues.ChartAreas[0].AxisX.Maximum = photoDatas.Count;
        ////    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(photoDatas.Count - xCount, photoDatas.Count);
        ////    ChtSensorValues.ChartAreas[0].AxisX.Interval = photoDatas.Count / 4;
        ////}

        ////private void MenuSubItemExit_Click(object sender, EventArgs e)
        ////{
        ////    Application.Exit();
        ////}

        ////private void MenuSubItemStart_Click(object sender, EventArgs e)
        ////{
        ////    IsSimulation = true;
        ////    timer.Interval = 1000;
        ////    timer.Tick += Timer_Tick;
        ////    timer.Start();

        ////    // serial통신 끊기
        ////    BtnDisconnect_Click(sender, e);
        ////}

        ////private void Timer_Tick(object sender, EventArgs e)
        ////{
        ////    ushort value = (ushort)rand.Next(1, 1024);
        ////    DisplayValue(value.ToString());
        ////}

        ////private void MenuSubItemStop_Click(object sender, EventArgs e)
        ////{
        ////    timer.Stop();
        ////    IsSimulation = false;

        ////    // serial 통신 재시작
        ////    BtnConnect_Click(sender, e);
        ////}

        ////private void MenuSubItemInfo_Click(object sender, EventArgs e)
        ////{
        ////    ThisProgramForm form = new ThisProgramForm();
        ////    form.ShowDialog();
        ////}

    }
}
#endregion