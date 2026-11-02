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
            ReservationEditor.SaveAttempt += ReservationEditorAttempt;
            ReservationEditor.CancelAttempt += ReservationEditorAttempt;
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

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Hotel hotel && ReservationsDataGrid.SelectedItem is Reservation selectedItem)
            {
                ReservationEditor.GuestComboBox.ItemsSource = hotel.Guests
                    .Select(guest => guest.ToString())
                    .ToList();
                ReservationEditor.RoomComboBox.ItemsSource = hotel.Rooms;
                ReservationEditor.DataContext = selectedItem;
                ReservationPanel.Visibility = Visibility.Collapsed;
                ReservationEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Reservation Selected.");
            }
        }

        private void ReservationEditorAttempt(object? sender, EventArgs e)
        {
            ReservationEditor.Visibility = Visibility.Collapsed;
            ReservationPanel.Visibility = Visibility.Visible;
            ReservationEditor.DataContext = null;
        }

        private void CancelReservationClick(object sender, RoutedEventArgs e)
        {
            if (ReservationsDataGrid.SelectedItem is Reservation selectedItem)
            {
                if (selectedItem.Status == ReservationStatus.Cancelled.ToString())
                {
                    MessageBox.Show("This reservation is already cancelled.");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem.Status = ReservationStatus.Cancelled.ToString();
                }

            }
            else
            {
                MessageBox.Show("No Reservation Selected.");
            }
        }
    }
}
