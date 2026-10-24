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
    /// Interaction logic for AddGuestWindow.xaml
    /// </summary>
    public partial class AddGuestWindow : Window
    {
        private readonly Hotel _hotel;

        public AddGuestWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            IDTypeComboBox.ItemsSource = Enum.GetValues(typeof(IDType));
        }

        private void AddGuestButtonClick(object sender, RoutedEventArgs e)
        {

            Guest guest = new Guest();

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }
            else
            {
                guest.FirstName = FirstNameTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter a Last Name.");
                return;
            }
            else
            {
                guest.LastName = LastNameTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return;
            }
            else
            {
                guest.PhoneNumber = PhoneNumberTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Please enter an Address.");
                return;
            }
            else
            {
                guest.Address = AddressTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter an Email.");
                return;
            }
            else
            {
                guest.Email = EmailTextBox.Text;
            }

            if (IDTypeComboBox.SelectedItem != null)
            {
                guest.IDType = (IDType)IDTypeComboBox.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select an ID Type.");
                return;
            }

            if (string.IsNullOrWhiteSpace(IDNumberTextBox.Text))
            {
                MessageBox.Show("Please enter an ID Number.");
                return;
            }
            else
            {
                guest.IDNumber = IDNumberTextBox.Text;
            }


            guest.GuestID = "GST-" + guest.LastName.Substring(0, 2).ToUpper() + "-" + guest.IDNumber.Substring(guest.IDNumber.Length - 3, 3);

            _hotel.Guests.Add(guest);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
