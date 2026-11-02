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
    /// Interaction logic for GuestEditControl.xaml
    /// </summary>
    public partial class GuestEditControl : UserControl
    {
        public GuestEditControl()
        {
            InitializeComponent();
            IDTypeComboBox.ItemsSource = Enum.GetValues(typeof(IDType));
        }

        public event EventHandler? CancelAttempt;
        public event EventHandler? SaveAttempt;

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Guest guest)
            {
                MessageBox.Show("Select a guest to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || LastNameTextBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("Please enter a Last Name with at least two characters.");
                return;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Please enter an Address.");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter an Email.");
                return;
            }

            if (IDTypeComboBox.SelectedItem is not IDType)
            {
                MessageBox.Show("Please select an ID Type.");
                return;
            }

            if (string.IsNullOrWhiteSpace(IDNumberTextBox.Text) || IDNumberTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Please enter an ID Number with at least three characters.");
                return;
            }

            UpdateValues();
            guest.GuestID = $"GST-{guest.LastName.Substring(0, 2).ToUpper()}-{guest.IDNumber.Substring(guest.IDNumber.Length - 3, 3)}";
            SaveAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancelAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateValues()
        {
            FirstNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            LastNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            PhoneNumberTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            AddressTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            EmailTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            IDTypeComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            IDNumberTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CheckedInCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();
        }
    }
}
