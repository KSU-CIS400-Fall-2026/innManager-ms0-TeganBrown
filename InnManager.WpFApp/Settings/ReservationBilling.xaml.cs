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

namespace InnManager.WpFApp.Settings
{
    /// <summary>
    /// Interaction logic for ReservationBilling.xaml
    /// </summary>
    public partial class ReservationBilling : UserControl
    {
        public ReservationBilling()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;

            hotel.TaxRate = decimal.TryParse(TaxRateTextBox.Text, out decimal taxRate) ? taxRate : 0;
            hotel.DefaultCheckInTime = new TimeSpan(int.TryParse(CheckInHourTextBox.Text, out int checkInHours) ? checkInHours : 0, int.TryParse(CheckInMinuteTextBox.Text, out int checkInMinutes) ? checkInMinutes : 0, 0);
            hotel.DefaultCheckOutTime = new TimeSpan(int.TryParse(CheckOutHourTextBox.Text, out int checkOutHours) ? checkOutHours : 0, int.TryParse(CheckOutMinuteTextBox.Text, out int checkOutMinutes) ? checkOutMinutes : 0, 0);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
