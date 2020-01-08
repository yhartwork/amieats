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
using System.Data;

namespace amieats.View
{

    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Page
    {

        private Controller.DetailController cDetail;

        public Detail(DataRow dataDetail, View.Home vHome)
        {
            InitializeComponent();

            this.cDetail = new Controller.DetailController(this, dataDetail, vHome);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            cDetail.addQty();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            cDetail.subQty();
        }

        private void cboxVariasi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cDetail.updateVariasi();
        }

        private void btnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cDetail.addToCart();
        }
    }
}
