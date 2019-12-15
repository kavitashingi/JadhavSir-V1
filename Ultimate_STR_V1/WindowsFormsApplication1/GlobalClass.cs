using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class GlobalClass
    {
        //public static SqlDataAdapter adap;
        public static MySqlDataAdapter adap;
        public static DataTable dt;       
        public static MySqlCommandBuilder bldr;
    }
}
