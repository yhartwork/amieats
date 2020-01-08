using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class ItemTransaksiModel
    {
        //object class Connection
        private SqlConnection conn;
        private SqlCommand command;

        //declare variable
        private string query;
        private bool hasil;

        //constructor 
        public ItemTransaksiModel()
        {
            conn = Connection.GetConnection();
        }

        //declare attribute
        private int id_item;
        private int id_variasi;
        private int id_menu;
        private int id_transaksi;
        private int subtotal;
        private string status;
        private string note;
        private int qty;

        public void SetId_variasi(int data)
        {
            id_variasi = data;
        }

        public void SetId_menu(int data)
        {
            id_menu = data;
        }

        public void SetId_transaksi(int data)
        {
            id_transaksi = data;
        }

        public void SetSubtotal(int data)
        {
            subtotal = data;
        }

        public void SetStatus(string data)
        {
            status = data;
        }

        public void SetQty(int data)
        {
            qty = data;
        }

        public void setNote(string data)
        {
            note = data;
        }
            
      

        //menampilkan select

        public DataSet SelectItemTransaksi()
        {
            DataSet itemtransaksi = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM transaksi_item WHERE id_transaksi=" + id_transaksi+"";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(itemtransaksi, "itemtransaksi");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return itemtransaksi;
        }

        //insert

        public Boolean InsertItemTransaksi()
        {
            try
            {

                var clean_id_variasi = "null";

                if(id_variasi == 0)
                {
                    clean_id_variasi = "null";
                } else
                {
                    clean_id_variasi = id_variasi.ToString();
                }

                query = "INSERT INTO transaksi_item (id_variasi, id_menu, id_transaksi, subtotal, qty, note, status_transaksi) VALUES(" + clean_id_variasi + "," + id_menu + "," + id_transaksi + "," + subtotal + "," + qty + ", '"+note+"', '"+status+"')";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                hasil = true;
                conn.Close();
            }
            catch (SqlException err)
            {
                hasil = false;
                Console.WriteLine(err);
                Console.WriteLine(query);
            }
            return hasil;
        }

        //update

        public Boolean UpdateItemTransaksi()
        {
            hasil = false;
            try
            {
                query = "UPDATE transaksi_item SET  qty ="+qty+" WHERE id_item="+id_item+"" ;
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
