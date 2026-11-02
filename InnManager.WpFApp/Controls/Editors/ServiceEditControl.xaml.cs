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
    /// Interaction logic for ServiceEditControl.xaml
    /// </summary>
    public partial class ServiceEditControl : UserControl
    {
        public ServiceEditControl()
        {
            InitializeComponent();
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(ServiceCategory));
        }

        public event EventHandler? CancelAttempt;
        public event EventHandler? SaveAttempt;

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Service)
            {
                MessageBox.Show("Select a service to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Please enter a Service Name.");
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid Price.");
                return;
            }

            if (CategoryComboBox.SelectedItem is not ServiceCategory)
            {
                MessageBox.Show("Please select a Category.");
                return;
            }

            if (!IsAvailableCheckBox.IsChecked.HasValue)
            {
                MessageBox.Show("Please specify service availability.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a Description.");
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
            NameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            PriceTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CategoryComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            IsAvailableCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
    }
}
