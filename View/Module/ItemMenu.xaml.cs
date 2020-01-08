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
using System.Windows.Media.Animation;

namespace amieats.View.Module
{
    /// <summary>
    /// Interaction logic for ItemMenu.xaml
    /// </summary>
    public partial class ItemMenu : UserControl
    {
        private int id;

        public ItemMenu(int id, string nama, int harga, string foto)
        {
            InitializeComponent();

            BitmapImage image = new BitmapImage(new Uri("/amieats;component/Image/menu/" + foto + ".png", UriKind.Relative));

            lblMenu.Content = nama;
            imageMenu.Source = image;
            lblHarga.Content = "Rp " + harga.ToString();

            this.id = id;

            animate();
        }

        public void animate()
        {
            // animate it
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3), FillBehavior.HoldEnd);
            fadeIn.BeginTime = TimeSpan.FromSeconds(0);

            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(fadeIn, borderMenu);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("(Opacity)"));
            sb.Children.Add(fadeIn);
            this.Resources.Clear();
            this.Resources.Add("MyEffect", sb);

            sb.Begin();
        }

        public int getId()
        {
            return id;
        }
    }
}
