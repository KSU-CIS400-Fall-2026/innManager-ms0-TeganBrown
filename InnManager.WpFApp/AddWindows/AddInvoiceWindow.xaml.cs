using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for AddInvoiceWindow.xaml
    /// </summary>
    public partial class AddInvoiceWindow : Window
    {
        private readonly Hotel _hotel;
        public AddInvoiceWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            GuestComboBox.ItemsSource = _hotel.Guests;
            ReservationComboBox.ItemsSource = _hotel.Reservations;
            ServicesDataGrid.ItemsSource = _hotel.Services;
        }

        private void AddInvoiceButtonClick(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice();
            decimal tax = 1 + _hotel.TaxRate/100;

            if (GuestComboBox.SelectedItem != null)
            {
                invoice.Guest = (Guest)GuestComboBox.SelectedItem;
                invoice.GuestName = (string)GuestComboBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Guest.");
                return;
            }

            if (ReservationComboBox.SelectedItem != null)
            {
                Reservation reservation = (Reservation)ReservationComboBox.SelectedItem;
                invoice.RoomNumber = reservation.Room.roomNumber;
                invoice.BillingRecords.Add(new Charge()
                {
                    Amount = reservation.Room.NightlyRate * (reservation.CheckOutDate.DayOfYear - reservation.CheckInDate.DayOfYear),
                    Category = ChargeCategory.Room,
                    IsProcessed = true
                });
            }
            else
            {
                MessageBox.Show("Please select a Reservation.");
                return;
            }

            foreach (object s in ServicesDataGrid.Items)
            {
                if (SelectColumn.GetCellContent(s) is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    Service service = (Service)s;
                    invoice.BillingRecords.Add(new Charge()
                    {
                        Amount = service.Price,
                        Category = (ChargeCategory)Enum.Parse(typeof(ChargeCategory), service.Category.ToString()),
                        IsProcessed = true
                    });
                }
            }

            if (InvoiceDatePicker.SelectedDate.HasValue)
            {
                invoice.InvoiceDate = InvoiceDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter an Invoice Date");
                return;
            }

            if (DueDatePicker.SelectedDate.HasValue && invoice.InvoiceDate < DueDatePicker.SelectedDate.Value)
            {
                invoice.DueDate = DueDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter a Due Date");
                return;
            }

            invoice.InvoiceNumber = "INV-" + ((Guest)GuestComboBox.SelectedItem).ToString().Substring(0,2) + "-" + ((Guest)GuestComboBox.SelectedItem).IDNumber.Substring(((Guest)GuestComboBox.SelectedItem).IDNumber.Length-3, 3) + "-" + ((Reservation)ReservationComboBox.SelectedItem).Room.ToString();

            _hotel.Invoices.Add(invoice);
            

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
