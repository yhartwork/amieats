using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class TransaksiModel
    {
        //object class Connection
        private SqlConnection conn;
        private SqlCommand command;

        //declare variable
        private string query;
        private bool hasil;
        private string keranjang;

        //constructor 
        public TransaksiModel()
        {
            conn = Connection.GetConnection();
        }

        //declare attribute
        private int id_transaksi;
        private int id_item;
        private int id_variasi;
        private int id_kategori;
        private string nama;
        private string tanggal;
        private int total;
        private int subtotal;
        private string status_transaksi;
        private string metode_pembayaran;
        

        public void SetId_transaksi(int data)
        {
            id_transaksi = data;
        }

        public void SetId_item(int data)
        {
            id_item = data;
        }

        public void SetId_variasi(int data)
        {
            id_variasi = data;
        }

        public void SetId_kategori(int data)
        {
            id_kategori = data;
        }

        public void SetNama (string data)
        {
            nama = data;
        }

        public void SetTanggal(string data)
        {
            tanggal = data;
        }

        public void SetTotal(int data)
        {
            total = data;
        }

        public void SetSubtotal(int data)
        {
            subtotal = data;
        }

        public void SetStatustransaksi(string data)
        {
            status_transaksi = data;
        }

        public void SetMetode(string data)
        {
            metode_pembayaran = data;
        }
        // fungsi menampilkan semua menu 
        public DataSet SelectKeranjang()
        {
            DataSet keranjang = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM transaksi ";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(keranjang, "keranjang");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return keranjang;
        }

        // fungsi menampilkan semua menu 
        public DataSet SelectByWarung(int id_warung)
        {
            DataSet bywarung = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM transaksi JOIN transaksi_item ON transaksi.id_transaksi=transaksi_item.id_transaksi JOIN menu ON transaksi_item.id_menu=menu.id_menu WHERE menu.id_warung=id_menu";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(bywarung, "bywarung");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return bywarung;
        }


        public Boolean InsertIntoTransaksi()
        {
            try
            {
                query = "INSERT INTO transaksi VALUES(" + id_transaksi + "," + tanggal + "," + total +", '"+status_transaksi+"')";
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

        // edit keranjang 
        public Boolean UpdateStatus()
        {
            hasil = false;
            try
            {
                query = "UPDATE keranjang SET status="+status_transaksi+" WHERE id_transaksi="+id_transaksi+"";
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
