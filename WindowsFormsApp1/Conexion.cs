using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Conexion
    {
        public static SqlConnection conexion = new SqlConnection("workstation id=Fonseca1998.mssql.somee.com;packet size=4096;user id=fonseca1998_SQLLogin_1;pwd=t5fvbjqhdv;data source=fonsecq1998.mssql.somee.com;persist security info=False;initial catalog=fonseca1998");

    }
}
