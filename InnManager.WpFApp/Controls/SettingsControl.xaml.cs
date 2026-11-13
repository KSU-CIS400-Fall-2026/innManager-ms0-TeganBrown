using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InnManager.WpFApp.Controls
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void HotelInfoClick(object sender, RoutedEventArgs e)
        {
            HotelInfo hotelInfo = new HotelInfo();
            SettingsContentControl.Content = hotelInfo;
        }

        private void ReservationBillingClick(object sender, RoutedEventArgs e)
        {
            ReservationBilling reservationBilling = new ReservationBilling();
            SettingsContentControl.Content = reservationBilling;
        }

        private void AccountClick(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            SettingsContentControl.Content = account;
        }
    }
}
