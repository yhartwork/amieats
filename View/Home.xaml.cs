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

namespace amieats.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {

        //declare object controller
        private Controller.HomeController cHome;

        public Home()
        {
            InitializeComponent();
            cHome = new Controller.HomeController(this);
        }

        void categoryClick(object sender, RoutedEventArgs e)
        {

            // Reset all color
            UIElementCollection childrenList = gridCategory.Children;
            foreach (View.Module.ItemCategory child in childrenList)
            {
                child.unselect();
            }

            // Change clicked element color
            View.Module.ItemCategory src = sender as View.Module.ItemCategory;
            src.select();

            // Load the menu
            cHome.showMenu(src.getId());
        }

        void menuClick(object sender, RoutedEventArgs e)
        {
            View.Module.ItemMenu src = sender as View.Module.ItemMenu;

            // load from database
            cHome.loadMenuDetail(src.getId());

            // display popup
            openPopup();
        }

        public void updateCartLabel(int qty, int total)
        {
            string label = qty + " item (Rp " + total + ")";
            lblTotal.Content = label;
        }

        public void activateMenu()
        {
            UIElementCollection menuList = gridMenu.Children;

            foreach (UIElement child in menuList)
            {
                child.MouseDown += new MouseButtonEventHandler(menuClick);
            }

        }

        public void activateCategory()
        {
            UIElementCollection categoryList = gridCategory.Children;

            foreach (UIElement child in categoryList)
            {
                child.MouseDown += new MouseButtonEventHandler(categoryClick);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Cart());
        }

        private void borderClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            closePopup();
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            // close overlay window
            overlay.Visibility = Visibility.Hidden;
        }

        public void openPopup()
        {
            // open overlay window
            overlay.Visibility = Visibility.Visible;

            // make easing function
            ElasticEase easing = new ElasticEase();
            easing.EasingMode = EasingMode.EaseOut;
            easing.Oscillations = 2;
            easing.Springiness = 10;

            // animate it
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3), FillBehavior.HoldEnd);
            DoubleAnimation bounce = new DoubleAnimation(50, 350, TimeSpan.FromSeconds(1), FillBehavior.HoldEnd);
            fadeIn.BeginTime = TimeSpan.FromSeconds(0);
            bounce.BeginTime = TimeSpan.FromSeconds(0);
            bounce.EasingFunction = easing;

            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(fadeIn, overlay);
            Storyboard.SetTarget(bounce, borderDetail);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("(Opacity)"));
            Storyboard.SetTargetProperty(bounce, new PropertyPath("(Height)"));
            sb.Children.Add(fadeIn);
            sb.Children.Add(bounce);
            this.Resources.Clear();
            this.Resources.Add("MyEffect", sb);

            sb.Begin();
        }

        public void closePopup()
        {
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.3), FillBehavior.HoldEnd);
            fadeOut.BeginTime = TimeSpan.FromSeconds(0);

            Storyboard sb = new Storyboard();
            Storyboard.SetTarget(fadeOut, overlay);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath("(Opacity)"));
            sb.Children.Add(fadeOut);
            this.Resources.Clear();
            this.Resources.Add("MyEffect", sb);
            sb.Completed += Sb_Completed;

            sb.Begin();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            parent.DragMove();
        }
    }
}
