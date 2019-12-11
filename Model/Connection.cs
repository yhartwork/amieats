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
                conn = new SqlConnection("Server=ICTDEVELOPER/SQLEXPRESS;Database=amieats;Trusted_Connection=Yes;");
                return conn;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
