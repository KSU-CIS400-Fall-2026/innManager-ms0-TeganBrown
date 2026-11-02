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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private readonly Hotel _hotel;

        public AddEmployeeWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            PositionComboBox.ItemsSource = Enum.GetValues(typeof(EmployeePosition));
        }

        private void AddEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }
            else
            {
                employee.FirstName = FirstNameTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter a Last Name.");
                return;
            }
            else
            {
                employee.LastName = LastNameTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return;
            }
            else
            {
                employee.PhoneNumber = PhoneNumberTextBox.Text;
            }

            if (IsActiveCheckBox.IsChecked.HasValue)
            {
                employee.IsActive = IsActiveCheckBox.IsChecked.Value;
            }
            else
            {
                MessageBox.Show("Please specify employee status");
                return;
            }

            if (PositionComboBox.SelectedItem != null)
            {
                employee.Position = (EmployeePosition)PositionComboBox.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select a Position.");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return;
            }
            else
            {
                employee.Email = EmailTextBox.Text;
            }

            if (HireDateDatePicker.SelectedDate.HasValue)
            {
                employee.HireDate = HireDateDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter a Hire Date");
                return;
            }

            employee.EmployeeID = "EMP-" + employee.LastName.Substring(0, 2).ToUpper() + "-" + employee.PhoneNumber.Substring(employee.PhoneNumber.Length - 3, 3);

            _hotel.Employees.Add(employee);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
