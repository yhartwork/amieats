using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace amieats.Model
{
    class Laporan
    {
        //object class Connection
        private SqlConnection conn;
        private SqlCommand command;

        //declare variable
        private string Tglsekarang;

        public DataSet SelectTransaksi()
        {
            DataSet transaksi = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM transaksi_item JOIN transaksi ON transaksi.id_transaksi=transaksi_item.id_transaksi WHERE transaksi.tanggal='"+Tglsekarang+"'";
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(transaksi, "transaksi");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return transaksi;
        }

    }
}
