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
    /// Interaction logic for ReservationsControl.xaml
    /// </summary>
    public partial class ReservationsControl : UserControl
    {

        

        public ReservationsControl()
        {
            InitializeComponent();
        }

        private void AddReservationClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddReservationWindow addReservationWindow = new AddReservationWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addReservationWindow.ShowDialog();
        }
    }
}
