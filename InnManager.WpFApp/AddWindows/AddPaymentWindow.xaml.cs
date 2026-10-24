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
    /// Interaction logic for AddPaymentWindow.xaml
    /// </summary>
    public partial class AddPaymentWindow : Window
    {
        private readonly Hotel _hotel;
        public AddPaymentWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            InvoiceComboBox.ItemsSource = _hotel.Invoices;
            PaymentMethodComboBox.ItemsSource = Enum.GetValues(typeof(PaymentMethod));
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPaymentButtonClick(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment();

            if (InvoiceComboBox.SelectedItem != null)
            {
                ((Invoice)InvoiceComboBox.SelectedItem).BillingRecords.Add(payment);
            }
            else
            {
                MessageBox.Show("Please select an Invoice.");
                return;
            }

            if (PaymentMethodComboBox.SelectedItem != null)
            {
                payment.PaymentMethod = (PaymentMethod)PaymentMethodComboBox.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select a Payment Method.");
                return;
            }


            if (PaymentDatePicker.SelectedDate.HasValue)
            {
                payment.date = PaymentDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter a Payment Date");
                return;
            }

            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                payment.Amount = amount;
            }
            else
            {
                MessageBox.Show("Please enter a valid Amount ($).");
                return;
            }

            payment.RefrenceNumber = "PAY-" + ((Invoice)InvoiceComboBox.SelectedValue).GuestName.Substring(0, 2).ToUpper() + "-" + ((Invoice)InvoiceComboBox.SelectedValue).Guest.GuestID.Substring(((Invoice)InvoiceComboBox.SelectedValue).Guest.GuestID.Length - 3, 3) + "-" + ((Invoice)InvoiceComboBox.SelectedValue).RoomNumber;

            _hotel.Payments.Add(payment);

            this.Close();
        }
    }
}
