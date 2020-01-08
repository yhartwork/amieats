using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class VariasiModel
    {
        // SQL Connection
        private SqlConnection conn;
        private SqlCommand command;

        // Data operation
        private string query;
        private bool hasil;

        //constructor 
        public VariasiModel()
        {
            conn = Connection.GetConnection();
        }


        public DataSet SelectVariasiMenu(int id_menu)
        {
            DataSet variasi = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM variasi WHERE id_menu=" + id_menu;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(variasi, "variasi");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return variasi;
        }
    }
}
