using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class MenuModel
    {
        //object class Connection
        private SqlConnection conn;
        private SqlCommand command;

        //declare variable
        private string query;
        private bool hasil;

        //constructor 
        public MenuModel()
        {
            conn = Connection.GetConnection();
        }

        //declare attribute
        private int id_menu;
        private string nama;
        private string foto;
        private string deskripsi;
        private int harga;
        private int id_warung;
        private int id_kategori;

        public int GetId_menu()
        {
            return id_menu;
        }

        public void SetId_menu(int data)
        {
            id_menu = data;
        }

        public string GetNama()
        {
            return nama;
        }

        public void SetNama(string data)
        {
            nama = data;
        }

        public string GetFoto()
        {
            return foto;
        }

        public void SetFoto(string data)
        {
            foto = data;
        }

        public string GetDeskripsi()
        {
            return deskripsi;
        }

        public void SetDeskripsi(string data)
        {
            deskripsi = data;
        }

        public int GetHarga()
        {
            return harga;
        }

        public void SetHarga(int data)
        {
           harga = data;
        }

        public int GetId_warung()
        {
            return harga;
        }

        public void SetId_warung(int data)
        {
            id_warung = data;
        }

        public int GetId_kategori()
        {
            return id_kategori;
        }

        public void SetId_kategori(int data)
        {
           id_kategori = data;
        }

        // fungsi menampilkan semua menu berdasarkan kategori
        public DataSet SelectMenu(int id_kategori)
        {
            DataSet daftarmenu = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM menu WHERE id_kategori=" + id_kategori;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(daftarmenu, "menu");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return daftarmenu;
        }

        // fungsi menampilkan detail menu

        public DataSet SelectDetailMenu(int id_kategori)
        {
            DataSet daftarmenu = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM menu WHERE id_menu=" + id_menu;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(daftarmenu, "menu");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return daftarmenu;
        }

        // menambahkan menu baru
        public Boolean InsertMenu()
        {
            try
            {
                query = "INSERT INTO menu VALUES()";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                hasil = true;
                conn.Close();
            }
            catch (SqlException)
            {
                hasil = false;
            }
            return hasil;
        }

        // edit daftar menu
        public Boolean UpdateMenu()
        {
            hasil = false;
            try
            {
                query = "UPDATE menu SET nama= '" + nama + "',foto='" + foto + "', deskripsi = '" + deskripsi + "', harga=" + harga + ", id_warung=" + id_warung + ", id_kategori=" + id_kategori + "";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                hasil = true;
                conn.Close();
            }
            catch (SqlException)
            {
                hasil = false;
            }
            return hasil;
        }


    }
}
