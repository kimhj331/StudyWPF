using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdCaliburnApp.Helpers
{
    class Commons
    {
        public static readonly string CONNSTRING =
           "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=mysql_p@ssw0rd";
        public static readonly string SELECT_EMPLYEES =
            " SELECT id, EmpName, salary, DeptName, Destination " +
            "   FROM emplyeestbl " +
            "  ORDER BY id ";

        public static readonly string UPDATE_EMPLYEE =
            "UPDATE emplyeestbl " +
            "   SET  " +
            "       EmpName = @EmpName, " +
            "       salary  = @salary, " +
            "      DeptName = @DeptName, " +
            "   Destination = @Destination " +
            "      WHERE id = @id ";

    }
}
