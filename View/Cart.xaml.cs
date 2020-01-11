using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amieats.View
{
    /// <summary>
    /// Interaction logic for Pay.xaml
    /// </summary>
    public partial class Cart : Page
    {


        //declare object controller
        private Controller.CartController cCart;

        public Cart()
        {
            InitializeComponent();
            cCart = new Controller.CartController(this);
        }

        public void updateTotal()
        {
            cCart.updateTotal();
        }

        public void updateCart()
        {
            cCart.updateCart();
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            parent.DragMove();
        }

        private void btnGotoPay_Click(object sender, RoutedEventArgs e)
        {
            string kode = kodeMeja.Text;
            NavigationService.Navigate(new Pay(kode));
        }
    }
}
