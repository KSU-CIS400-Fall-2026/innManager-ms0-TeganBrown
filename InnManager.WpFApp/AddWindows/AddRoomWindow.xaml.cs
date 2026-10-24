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
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {

        private readonly Hotel _hotel;

        public AddRoomWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType));
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(RoomStatus));
        }
        /// <summary>
        /// Creates a room object based on the criteria given, and adds it to the hotel's database
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">the event being signaled</param>
        private void AddRoomButtonClick(object sender, RoutedEventArgs e)
        {
            Room room = new Room();
            if (string.IsNullOrWhiteSpace(RoomNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a room number.");
                return;
            }
            else
            {
                room.roomNumber = RoomNumberTextBox.Text;
            }

            if (RoomTypeComboBox.SelectedItem != null)
            {
                room.roomType = (RoomType)RoomTypeComboBox.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            if (decimal.TryParse(RateTextBox.Text, out decimal nightlyRate) && nightlyRate > 0)
            {
                room.NightlyRate = nightlyRate;
            }
            else
            {
                MessageBox.Show("Please enter a valid nightly rate.");
                return;
            }
            
            if (int.TryParse(FloorTextBox.Text, out int floor) && floor > 0)
            {
                room.Floor = floor;
            }
            else
            {
                MessageBox.Show("Please enter a valid floor number.");
                return;
            }

            if (int.TryParse(CapacityTextBox.Text, out int capacity) && capacity > 0)
            {
                room.Capacity = capacity;
            }
            else
            {
                MessageBox.Show("Please enter a valid capacity.");
                return;
            }

            if (HasBalconyCheckBox.IsChecked.HasValue)
            {
                room.HasBalcony = HasBalconyCheckBox.IsChecked.Value;
            }
            else
            {
                MessageBox.Show("Please specify if the room has a balcony.");
                return;
            }

            if (IsCleanCheckBox.IsChecked.HasValue)
            {
                room.IsClean = IsCleanCheckBox.IsChecked.Value;
            }
            else
            {
                MessageBox.Show("Please specify if the room is clean.");
                return;
            }

            if (StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a room status.");
                return;
            }
            else
            {
                room.Status = (RoomStatus)StatusComboBox.SelectedItem;
            }

            if (room.Status == RoomStatus.Available)
            {
                room.isAvailable = true;

            }
            else
            {
                room.isAvailable = false;
            }

            _hotel.Rooms.Add(room);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
