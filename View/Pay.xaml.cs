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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amieats.View
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Pay : Page
    {
        public Pay()
        {
            InitializeComponent();
        }

        private void btnBackToCart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        void animatePaymentPopup()
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

        private void payGopay_Click(object sender, RoutedEventArgs e)
        {
            frmPay.Content = new Module.PatmentGopay();
            animatePaymentPopup();
        }

        private void payOVO_Click(object sender, RoutedEventArgs e)
        {
            frmPay.Content = new Module.PaymentOVO();
            animatePaymentPopup();
        }

        private void payEM_Click(object sender, RoutedEventArgs e)
        {
            frmPay.Content = new Module.PatmentEM();
            animatePaymentPopup();
        }

        private void payCash_Click(object sender, RoutedEventArgs e)
        {
            frmPay.Content = new Module.PaymentCash();
            animatePaymentPopup();
        }

        private void borderClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // animate it
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

        private void Sb_Completed(object sender, EventArgs e)
        {
            // close overlay window
            overlay.Visibility = Visibility.Hidden;
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                NavigationService.Navigate(new Success());
            }
        }
    }
}
