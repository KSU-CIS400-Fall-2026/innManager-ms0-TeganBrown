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
    /// Interaction logic for EmployeeEditControl.xaml
    /// </summary>
    public partial class EmployeeEditControl : UserControl
    {
        public EmployeeEditControl()
        {
            InitializeComponent();
            PositionComboBox.ItemsSource = Enum.GetValues(typeof(EmployeePosition));
        }

        public event EventHandler? CancelAttempt;
        public event EventHandler? SaveAttempt;

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Employee)
            {
                MessageBox.Show("Select an employee to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter a First Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter a Last Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return;
            }

            if (PositionComboBox.SelectedItem is not EmployeePosition)
            {
                MessageBox.Show("Please select a Position.");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter an Email.");
                return;
            }

            if (!HireDateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please enter a Hire Date.");
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
            FirstNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            LastNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            PhoneNumberTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            IsActiveCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();
            PositionComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            EmailTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            HireDateDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty)?.UpdateSource();
        }
    }
}
