using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace amieats.Model
{
    class Connection
    {
        private static SqlConnection conn;

        public static SqlConnection GetConnection()
        {
            try
            {
                conn = new SqlConnection("Data Source=ICTDEVELOPER\\SQLEXPRESS;" +
                "Initial Catalog=amieats;" +
                "Integrated Security=true");
                return conn;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
