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

        //constructor 
        public TransaksiModel()
        {
            conn = Connection.GetConnection();
        }

        //declare attribute
        private int id_transaksi;
        private string tanggal;
        private int total;
        private string kode_meja;
        private string metode_pembayaran;
        

        public void SetTanggal(string data)
        {
            tanggal = data;
        }

        public void SetTotal(int data)
        {
            total = data;
        }

        public void setKodeMeja(string data)
        {
            kode_meja = data;
        }

        public void SetMetode(string data)
        {
            metode_pembayaran = data;
        }

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


        public int InsertTransaksi()
        {
            int id;
            DataSet transaksi = new DataSet();
            try
            {
                query = "INSERT INTO transaksi (tanggal, total, kode_meja, metode_pembayaran) OUTPUT INSERTED.id_transaksi VALUES('" + tanggal + "'," + total +", '"+kode_meja+"', '"+metode_pembayaran+"')";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                //command.ExecuteNonQuery();
                //id = (int) command.ExecuteScalar();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(transaksi, "transaksi");
                conn.Close();

                return int.Parse(transaksi.Tables[0].Rows[0]["id_transaksi"].ToString());
            }
            catch (SqlException)
            {
                id = 0;
            }
            return id;
        }

    }
}
