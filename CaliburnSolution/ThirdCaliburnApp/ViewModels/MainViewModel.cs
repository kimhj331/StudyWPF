using Caliburn.Micro;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ThirdCaliburnApp.Helpers;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {

        #region 속성영역
        private BindableCollection<EmployeesModel> employees;

        //전체 Employ 리스트
        public BindableCollection<EmployeesModel> Employees 
        { 
            get => employees;
            set 
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
            } 
        }


        //선택된 하나의 Employee
        EmployeesModel selectedEmployee;

        public EmployeesModel SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;

                Id = value.Id;
                EmpName = value.EmpName;
                Salary = value.Salary;
                DeptName = value.DeptName;
                Destination = value.Destination;
                
                NotifyOfPropertyChange(() => SelectedEmployee);
                
            }
        }

        int id;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        string empName;

        public string EmpName 
        {
            get => empName;
            set 
            {
                empName = value;
                NotifyOfPropertyChange(() => EmpName);
            }
        }

        decimal salary;
        public decimal Salary
        {
            get => salary;
            set
            {
                salary = value;
                NotifyOfPropertyChange(() => Salary);
            }
        }

        string deptName;
        public string DeptName
        {
            get => deptName;
            set
            {
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
            }
        }

        string destination;
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                NotifyOfPropertyChange(() => Destination);
            }
        }
        #endregion

        #region 생성자
        public MainViewModel()
        {
            GetEmployees();
        }

        #endregion

        public void GetEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECT_EMPLYEES, conn);
                //cmd.Connection = conn;
                //커멘드가 커넥션으로 이어진다는것을 보여줘야됨
                MySqlDataReader reader = cmd.ExecuteReader();
                Employees = new BindableCollection<EmployeesModel>();

                while (reader.Read())
                {
                    var temp = new EmployeesModel
                    {
                        Id = (int)reader["id"], //[employsTBL속성값]
                        EmpName = reader["empName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        DeptName = reader["DeptName"].ToString(),
                        Destination = reader["Destination"].ToString()
                    };
                    Employees.Add(temp);
                }
            }
        }
        public void SaveEmployee()
        {
            int resultRow = 0;
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.UPDATE_EMPLYEE, conn);
                MySqlParameter paramEmpName = new MySqlParameter("@EmpName", MySqlDbType.VarChar, 45);
                paramEmpName.Value = EmpName;
                cmd.Parameters.Add(paramEmpName);

                MySqlParameter paramsalary = new MySqlParameter("@salary", MySqlDbType.Decimal);
                paramsalary.Value = Salary;
                cmd.Parameters.Add(paramsalary);

                MySqlParameter paramDeptName = new MySqlParameter("@DeptName", MySqlDbType.VarChar, 45);
                paramDeptName.Value = DeptName;
                cmd.Parameters.Add(paramDeptName);

                MySqlParameter paramDestination = new MySqlParameter("@Destination", MySqlDbType.VarChar, 45);
                paramDestination.Value = Destination;
                cmd.Parameters.Add(paramDestination);

                MySqlParameter paramId = new MySqlParameter("@id", MySqlDbType.Int32);
                paramId.Value = Id;
                cmd.Parameters.Add(paramId);

                resultRow = cmd.ExecuteNonQuery();
            }

            if (resultRow > 0)
            {
                MessageBox.Show("저장되었습니다");
                GetEmployees();
            }
        }
        public bool CanSaveEmployee
        {
            get 
            {
                return !((Id == 0) && (string.IsNullOrEmpty(EmpName) && (Salary == 0) &&
                    string.IsNullOrEmpty(DeptName) && string.IsNullOrEmpty(Destination)));
            } 
        }

        public void NewEmployee()
        { 
            
        }
    }
}
