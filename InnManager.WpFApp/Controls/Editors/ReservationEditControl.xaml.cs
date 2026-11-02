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

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for ReservationEditControl.xaml
    /// </summary>
    public partial class ReservationEditControl : UserControl
    {
        public ReservationEditControl()
        {
            InitializeComponent();
            StatusComboBox.ItemsSource = new[]
            {
                new KeyValuePair<string, bool>("Confirmed", true),
                new KeyValuePair<string, bool>("Unconfirmed", false)
            };
        }

        public event EventHandler? CancelAttempt;
        public event EventHandler? SaveAttempt;

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Reservation)
            {
                MessageBox.Show("Select a reservation to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(GuestComboBox.Text))
            {
                MessageBox.Show("Please select a Guest.");
                return;
            }

            if (RoomComboBox.SelectedItem is not Room selectedRoom)
            {
                MessageBox.Show("Please select a Room.");
                return;
            }

            if (!CheckInDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please enter a Check-In Date.");
                return;
            }

            if (!CheckOutDatePicker.SelectedDate.HasValue || CheckInDatePicker.SelectedDate.Value >= CheckOutDatePicker.SelectedDate.Value)
            {
                MessageBox.Show("Please enter a valid Check-Out Date.");
                return;
            }

            if (!int.TryParse(GuestNumTextBox.Text, out int guests) || guests < 1 || guests > selectedRoom.Capacity)
            {
                MessageBox.Show("Please enter a valid Number of Guests.");
                return;
            }

            if (StatusComboBox.SelectedValue is not bool)
            {
                MessageBox.Show("Please select a Status.");
                return;
            }

            UpdateValues();
            SaveAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancelAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateValues()
        {
            GuestComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            RoomComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
            CheckInDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty)?.UpdateSource();
            CheckOutDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty)?.UpdateSource();
            GuestNumTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            StatusComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
        }
    }
}
