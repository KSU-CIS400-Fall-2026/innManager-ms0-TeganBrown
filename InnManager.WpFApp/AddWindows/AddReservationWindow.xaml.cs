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
using System.Windows.Shapes;

namespace InnManager.WpFApp.AddWindows
{
    /// <summary>
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        private readonly Hotel _hotel;
        public AddReservationWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            GuestComboBox.ItemsSource = _hotel.Guests;
            RoomComboBox.ItemsSource = _hotel.Rooms;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(ReservationStatus));
        }

        private void AddReservationButtonClick(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();

            if (GuestComboBox.SelectedItem != null)
            {
                reservation.GuestName = (string)GuestComboBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Guest.");
                return;
            }

            if (RoomComboBox.SelectedItem != null)
            {
                reservation.RoomNumber = (string)RoomComboBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Room.");
                return;
            }

            if (CheckInDatePicker.SelectedDate.HasValue)
            {
                reservation.CheckInDate = CheckInDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter a Check-In Date");
                return;
            }

            if (CheckOutDatePicker.SelectedDate.HasValue && reservation.CheckInDate < CheckOutDatePicker.SelectedDate.Value)
            {
                reservation.CheckOutDate = CheckOutDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter a valid Check-Out Date");
                return;
            }

            if (!(int.TryParse(GuestNumTextBox.Text, out int guests) && guests > 0 && guests <= ((Room)RoomComboBox.SelectedItem).Capacity))
            {
                MessageBox.Show("Please enter a valid Number of Guests.");
                return;
            }

            if (StatusComboBox.SelectedItem != null)
            {
                if ((ReservationStatus)StatusComboBox.SelectedItem == ReservationStatus.Confirmed) reservation.Status = "Confirmed";
                else reservation.Status = "Unconfirmed";
            }
            else
            {
                MessageBox.Show("Please select a Status.");
                return;
            }

            reservation.ReservationNumber = "RES-" + reservation.GuestName.Substring(0, 2).ToUpper() + "-" + ((Guest)GuestComboBox.SelectedItem).IDNumber.Substring(((Guest)GuestComboBox.SelectedItem).IDNumber.Length - 3, 3) + "-" + reservation.RoomNumber;

            _hotel.Reservations.Add(reservation);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
