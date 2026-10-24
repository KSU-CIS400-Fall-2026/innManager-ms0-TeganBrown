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
    /// Interaction logic for AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private readonly Hotel _hotel;
        public AddServiceWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(ServiceCategory));
        }

        private void AddServiceButtonClick(object sender, RoutedEventArgs e)
        {
            Service service = new Service();

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Please enter a Service Name.");
                return;
            }
            else
            {
                service.ServiceName = NameTextBox.Text;
            }

            if (decimal.TryParse(PriceTextBox.Text, out decimal price) && price > 0)
            {
                service.Price = price;
            }
            else
            {
                MessageBox.Show("Please enter a valid Price.");
                return;
            }

            if (CategoryComboBox.SelectedItem != null)
            {
                service.Category = ((ServiceCategory)CategoryComboBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a Category.");
                return;
            }

            if (IsAvailableCheckBox.IsChecked.HasValue)
            {
                service.IsAvailable = IsAvailableCheckBox.IsChecked.Value;
            }
            else
            {
                MessageBox.Show("Please specify service availability");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a Description.");
                return;
            }
            else
            {
                service.Description = DescriptionTextBox.Text;
            }

            _hotel.Services.Add(service);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
