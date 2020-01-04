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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

        }

        void categoryClick(object sender, RoutedEventArgs e)
        {

            // Reset all color
            UIElementCollection childrenList = gridCategory.Children;
            foreach (Border child in childrenList)
            {
                child.Background = Brushes.Transparent;
            }

            // Change clicked element color
            Border src = sender as Border;
            src.Background = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0)); ;
        }

        void menuClick(object sender, RoutedEventArgs e)
        {
            // open overlay window
            overlay.Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UIElementCollection categoryList = gridCategory.Children;
            UIElementCollection menuList = gridMenu.Children;

            foreach (UIElement child in categoryList)
            {
                child.MouseDown += new MouseButtonEventHandler(categoryClick);
            }

            foreach(UIElement child in menuList)
            {
                child.MouseDown += new MouseButtonEventHandler(menuClick);
            }

            // Load frame detail
            frmDetail.Content = new Detail();
        }
    }
}
