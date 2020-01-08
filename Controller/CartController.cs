using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace amieats.Controller
{
    class CartController
    {

        private View.Cart vCart;

        public CartController(View.Cart vCart)
        {
            this.vCart = vCart;

            updateCart();
        }
        public void updateTotal()
        {
            int total = 0;

            foreach (CartItem item in CartitemList.Content)
            {
                total += (item.harga * item.qty);
            }

            // update total
            vCart.lblTotal.Content = "Rp " + total;
        }

        public void updateCart()
        {
            // clear the cart
            vCart.spCart.Children.Clear();

            int total = 0;
            int index = 0;
            foreach(CartItem item in CartitemList.Content)
            {
                BitmapImage image = new BitmapImage(new Uri("/amieats;component/Image/menu/" + item.foto + ".png", UriKind.Relative));
                View.Module.ItemCart iCart = new View.Module.ItemCart(index);
                iCart.lblHarga.Content = "@ Rp" + item.harga;
                iCart.lblNama.Content = item.nama + (item.nama_variasi != "" ? ": " + item.nama_variasi : "");
                iCart.lblWarung.Content = item.nama_warung;
                iCart.txtCatatan.Text = item.catatan;
                iCart.imageMenu.Source = image;
                iCart.setQty(item.qty);

                total += (item.harga * item.qty);

                vCart.spCart.Children.Add(iCart);
                vCart.spCart.Height += 110;

                index++;
            }

            updateTotal();

        }
    }
}
