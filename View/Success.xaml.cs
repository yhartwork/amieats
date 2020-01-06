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
    /// Interaction logic for Success.xaml
    /// </summary>
    public partial class Success : Page
    {
        public Success()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Delay(10000).ContinueWith(_ =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    NavigationService.Navigate(new View.Home());
                });
            }
            );
        }
    }
}
