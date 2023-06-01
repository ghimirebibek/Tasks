using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeProj.DBConnection
{
    public class DBConnection
    {
        public SqlConnection con;

        public void connect()
        {
            string connect = ConfigurationManager.ConnectionStrings["Test"].ToString();
            con = new SqlConnection(connect);
        }
    }
}