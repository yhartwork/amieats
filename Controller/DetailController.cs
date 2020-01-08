using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace amieats.Controller
{
    public class VariationItem
    {
        public int id_variasi { get; set; }
        public string label { get; set; }
        public int harga { get; set; }
        public string nama { get; set; }

        public VariationItem(int id_variasi, string nama, int harga)
        {
            this.id_variasi = id_variasi;
            this.label = nama + " (tambah Rp "+harga+")";
            this.harga = harga;
            this.nama = nama;
        }
    }

    class DetailController
    {
        private View.Detail vDetail;
        private View.Home vHome;
        private Model.VariasiModel mVariasi;

        private int id_menu;
        private string nama;
        private string deskripsi;
        private int harga;
        private int harga_tambahan = 0;
        private string foto;
        private int qty = 1;
        private int id_variasi = 0;
        private string nama_variasi;
        private string kategori;
        private string warung;


        public DetailController(View.Detail vDetail, DataRow detailData, View.Home vHome)
        {

            mVariasi = new Model.VariasiModel();
            this.vHome = vHome;

            this.vDetail = vDetail;
            this.id_menu = int.Parse(detailData["id_menu"].ToString());
            this.nama = detailData["nama"].ToString();
            this.harga = int.Parse(detailData["harga"].ToString());
            this.foto = detailData["foto"].ToString();
            this.kategori = detailData["kategori"].ToString();
            this.deskripsi = detailData["deskripsi"].ToString();
            this.warung = detailData["warung"].ToString();

            BitmapImage image = new BitmapImage(new Uri("/amieats;component/Image/menu/" + foto + ".png", UriKind.Relative));

            // display the detail
            vDetail.lblNama.Content = this.nama;
            vDetail.lblDeskripsi.Text = this.deskripsi;
            vDetail.lblCategory.Content = this.kategori;
            vDetail.lblQty.Content = this.qty;
            vDetail.lblWarung.Content = this.warung;
            vDetail.imageMenu.Source = image;

            // display the variation
            showVariation();

            // update subtotal
            updateSubtotal();
        }

        private void showVariation()
        {

            DataSet dataSet = mVariasi.SelectVariasiMenu(id_menu);
            ObservableCollection<VariationItem> variationList = new ObservableCollection<VariationItem>();

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                vDetail.spDetail.Children.RemoveAt(0);
            }
            else
            {
                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        int id = int.Parse(row["id_variasi"].ToString());
                        string nama = row["nama"].ToString();
                        int harga_tambahan = int.Parse(row["harga_tambahan"].ToString());

                        variationList.Add(new VariationItem(id, nama, harga_tambahan));
                    }
                }

                vDetail.cboxVariasi.ItemsSource = variationList;
            }
        }

        public void addToCart()
        {
            CartItem item = new CartItem();
            item.id_menu = id_menu;
            item.harga = harga + harga_tambahan;
            item.foto = foto;
            item.qty = this.qty;
            item.nama = nama;
            item.id_variasi = id_variasi;
            item.nama_variasi = nama_variasi;
            item.nama_warung = warung;

            CartitemList.Content.Add(item);

            // calculate total
            int totalPrice = 0;
            int count = 0;
            foreach (CartItem i in CartitemList.Content)
            {
                totalPrice += (i.harga * i.qty);
                count += i.qty;
            }


            vHome.updateCartLabel(count, totalPrice);

            // hide
            vHome.closePopup();
        }

        public void addQty()
        {
            this.qty++;
            updateSubtotal();
        }

        public void subQty()
        {
            this.qty--;
            updateSubtotal();
        }

        public void updateSubtotal()
        {
            int subtotal = (harga + harga_tambahan) * qty;
            string label = qty + " item (Rp " + subtotal + ")";

            vDetail.lblQty.Content = qty;
            vDetail.lblSubtotal.Content = label;
        }

        public void updateVariasi()
        {
            VariationItem selected = vDetail.cboxVariasi.SelectedItem as VariationItem;
            this.id_variasi = selected.id_variasi;
            this.harga_tambahan = selected.harga;
            this.nama_variasi = selected.nama;

            updateSubtotal();
        }
    }
}
