﻿using System;
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
        public Cart()
        {
            InitializeComponent();
        }

        private void btnGotoPay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pay());
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
