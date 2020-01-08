using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace amieats
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public class CartItem
    {
        public int id_menu;
        public string nama;
        public string foto;
        public int harga;
        public int qty;
        public int id_variasi = 0;
        public string nama_variasi;
        public string catatan;
        public string nama_warung;
    }

    public static class CartitemList
    {
        public static List<CartItem> Content = new List<CartItem>();
    }


    public partial class App : Application
    {

    }
}
