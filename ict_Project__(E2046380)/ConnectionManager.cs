using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ict_Project___E2046380_
{
    class ConnectionManager
    {
        public static SqlConnection newCon;
        public static string conStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            newCon = new SqlConnection(conStr);
            return newCon;
        }
    }
}
