﻿using System;
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


        public void SetId_menu(int data)
        {
            id_menu = data;
        }

        public void SetNama(string data)
        {
            nama = data;
        }

        public void SetFoto(string data)
        {
            foto = data;
        }

        public void SetDeskripsi(string data)
        {
            deskripsi = data;
        }

        public void SetHarga(int data)
        {
           harga = data;
        }

        public void SetId_warung(int data)
        {
            id_warung = data;
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

        public DataSet SelectDetailMenu(int id_menu)
        {
            DataSet detailmenu = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText =   "SELECT m.*, k.nama [kategori], w.nama [warung] FROM menu m " +
                                        "JOIN kategori k ON m.id_kategori=k.id_kategori " +
                                        "JOIN warung w ON m.id_warung=w.id_warung " +
                                        "WHERE id_menu=" + id_menu;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(detailmenu, "menu");
                conn.Close();
            }
            catch (SqlException)
            {

            }
            return detailmenu;
        }

        // menambahkan menu baru
        public Boolean InsertMenu()
        {
            try
            {
                query = "INSERT INTO menu VALUES("+id_menu+", '"+nama+"', '"+foto+"','"+deskripsi+"',"+harga+", "+id_warung+","+id_kategori+")";
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
