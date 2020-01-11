using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace amieats.Controller
{
    class HomeController
    {
        //declar view dan model
        private View.Home vHome;
        private Model.KategoriModel mKategori;
        private Model.MenuModel mMenu;

        //constructor
        public HomeController(View.Home vHome)
        {

            // panggil model
            this.vHome = vHome;
            mKategori = new Model.KategoriModel();
            mMenu = new Model.MenuModel();

            // muat kategori dan menu
            showCategory();
            showMenu(1);
        }

        public void showCategory()
        {

            DataSet dataSet = mKategori.SelectKategori();

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    int id = int.Parse(row["id_kategori"].ToString());
                    string nama = row["nama"].ToString();

                    View.Module.ItemCategory iCategory = new View.Module.ItemCategory(id, nama);
                    Grid.SetColumn(iCategory, id - 1);
                    vHome.gridCategory.Children.Add(iCategory);
                }
            }

            vHome.activateCategory();
        }

        public void showMenu(int id_kategori)
        {
            DataSet dataSet = mMenu.SelectMenu(id_kategori);

            vHome.gridMenu.Children.Clear();

            foreach (DataTable table in dataSet.Tables)
            {
                int index = 0;
                foreach (DataRow row in table.Rows)
                {

                    int id = int.Parse(row["id_menu"].ToString());
                    string nama = row["nama"].ToString();
                    string foto = row["foto"].ToString();
                    int harga = int.Parse(row["harga"].ToString());

                    View.Module.ItemMenu iMenu = new View.Module.ItemMenu(id, nama, harga, foto);

                    int posisiColumn = index % 5;
                    double posisiBaris = index / 5;

                    Grid.SetColumn(iMenu, posisiColumn);
                    Grid.SetRow(iMenu, (int) posisiBaris);

                    vHome.gridMenu.Children.Add(iMenu);

                    index++;
                }
            }

            vHome.activateMenu();
        }

        public void loadMenuDetail(int id_menu)
        {
            DataSet dataSet = mMenu.SelectDetailMenu(id_menu);
            DataRow row = dataSet.Tables[0].Rows[0];
            View.Detail menuDetail = new View.Detail(row, vHome);
            vHome.frmDetail.Content = menuDetail;
        }
    }
}
