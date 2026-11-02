using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using InnManager.Guests;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents an invoice for a guest's stay at the inn.
    /// </summary>
    /// <remarks>
    /// The Invoice class contains properties for storing invoice information such as GuestName, RoomNumber, RoomCharge, and ServiceCharge. It is used to manage invoices within the inn management system.
    /// </remarks>
    public class Invoice : INotifyPropertyChanged
    {
        private string _guestName = string.Empty;
        private string _roomNumber = string.Empty;
        private string _invoiceNumber = string.Empty;
        private DateTime _invoiceDate = DateTime.Now;
        private DateTime _dueDate = DateTime.Now;
        private Guest? _guest;
        private readonly HashSet<BillingRecord> _trackedBillingRecords = new();

        public Invoice()
        {
            BillingRecords.CollectionChanged += OnBillingRecordsChanged;
        }

        /// <summary>
        /// Gets or sets the name of the guest associated with the invoice.
        /// </summary>
        public string GuestName
        {
            get => _guestName;
            set
            {
                if (_guestName == value) return;
                _guestName = value;
                OnPropertyChanged(nameof(GuestName));
            }
        }
        /// <summary>
        /// Gets or sets the room number associated with the invoice.
        /// </summary>
        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (_roomNumber == value) return;
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        /// <summary>
        /// Gets the list of billing records associated with the invoice.
        /// </summary>
        public ObservableCollection<BillingRecord> BillingRecords { get; } = new();
        /// <summary>
        /// Gets the total charges for the invoice.
        /// </summary>
        public decimal TotalCharges => BillingRecords.OfType<Charge>().Where(c => c.IsProcessed).Sum(c => c.Amount);
        /// <summary>
        /// Gets the total payments for the invoice.
        /// </summary>
        public decimal TotalPayments => BillingRecords.OfType<Payment>().Where(p => p.IsProcessed).Sum(p => p.Amount);
        /// <summary>
        /// Gets the balance due for the invoice.
        /// </summary>
        public decimal BalanceDue => TotalCharges - TotalPayments;
        /// <summary>
        /// Gets the status of the invoice.
        /// </summary>
        public string Status
        {
            get
            {
                if (BalanceDue <= 0)
                {
                    return "Paid";
                }
                else
                {
                    return "Unpaid";
                }
            }
        }
        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set
            {
                if (_invoiceNumber == value) return;
                _invoiceNumber = value;
                OnPropertyChanged(nameof(InvoiceNumber));
            }
        }
        /// <summary>
        /// Gets or sets the date of the invoice.
        /// </summary>
        public DateTime InvoiceDate
        {
            get => _invoiceDate;
            set
            {
                if (_invoiceDate == value) return;
                _invoiceDate = value;
                OnPropertyChanged(nameof(InvoiceDate));
            }
        }
        /// <summary>
        /// Gets or sets the due date of the invoice.
        /// </summary>
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate == value) return;
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public Guest? Guest
        {
            get => _guest;
            set
            {
                if (_guest == value) return;
                _guest = value;
                OnPropertyChanged(nameof(Guest));
            }
        }

        public override string ToString()
        {
            return $"{GuestName}: {RoomNumber}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnBillingRecordsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (BillingRecord record in _trackedBillingRecords.Except(BillingRecords).ToList())
            {
                record.PropertyChanged -= OnBillingRecordPropertyChanged;
                _trackedBillingRecords.Remove(record);
            }

            foreach (BillingRecord record in BillingRecords)
            {
                if (_trackedBillingRecords.Add(record))
                {
                    record.PropertyChanged += OnBillingRecordPropertyChanged;
                }
            }

            OnBillingTotalsChanged();
        }

        private void OnBillingRecordPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BillingRecord.Amount)
                || e.PropertyName == nameof(BillingRecord.IsProcessed)
                || string.IsNullOrEmpty(e.PropertyName))
            {
                OnBillingTotalsChanged();
            }
        }

        private void OnBillingTotalsChanged()
        {
            OnPropertyChanged(nameof(TotalCharges));
            OnPropertyChanged(nameof(TotalPayments));
            OnPropertyChanged(nameof(BalanceDue));
            OnPropertyChanged(nameof(Status));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
