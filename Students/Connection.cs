using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Students
{
    class Connection
    {
        public static SqlConnection Conn()
        {
            SqlConnection cn = new SqlConnection(@"SERVER=LAPTOP-SG8V7THJ\SQLARIAS;DATABASE=BD_crud;integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
