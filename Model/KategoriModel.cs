using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class KategoriModel
    {
        //object class Connection
        private SqlConnection conn;
        private SqlCommand command;

        //declare variable
        private string query;
        private bool hasil;

        //constructor 
        public KategoriModel()
        {
            conn = Connection.GetConnection();
        }

        //declare attribute
        private int id_kategori;
        private string nama;

        public int GetId_kategori()
        {
            return id_kategori;
        }

        public void SetId_kategori(int data)
        {
            id_kategori = data;
        }

        public string GetNama()
        {
            return nama;
        }

        public void SetNama(string data)
        {
            nama = data;
        }

        //fungsi menampilkan kategori
        public DataSet SelectKategori(int id_kategori)
        {
            DataSet kategori = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM kategori WHERE id_kategori =" + id_kategori;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(kategori, "kategori");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return kategori;
        }
    

            
    }
}
