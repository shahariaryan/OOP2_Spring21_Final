using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project
{
    class Database
    {
        static SqlConnection conn;
        public static SqlConnection ConnectDB()
        {
            string connString = @"Server=DESKTOP-F2QN1PO\SQLEXPRESS;Database=Project;User Id=sa;Password=165757;";
             conn = new SqlConnection(connString);
            return conn;
        }

    } 
}
