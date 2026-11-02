using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a billing record with properties for amount, date, description, processing status, and signed amount.
    /// </summary>
    public abstract class BillingRecord : IBillingRecord, INotifyPropertyChanged
    {
        private decimal _amount = decimal.Zero;
        private DateTime _date = DateTime.Now;
        private string _description = string.Empty;
        private bool _isProcessed;

        /// <summary>
        /// Gets or sets the amount associated with the billing record.
        /// </summary>
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount == value) return;
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                OnPropertyChanged(nameof(SignedAmount));
            }
        }
        /// <summary>
        /// Gets or sets the date of the billing record.
        /// </summary>
        public DateTime date
        {
            get => _date;
            set
            {
                if (_date == value) return;
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }
        /// <summary>
        /// Gets or sets the description of the billing record.
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the billing record has been processed.
        /// </summary>
        public bool IsProcessed
        {
            get => _isProcessed;
            set
            {
                if (_isProcessed == value) return;
                _isProcessed = value;
                OnPropertyChanged(nameof(IsProcessed));
            }
        }
        /// <summary>
        /// Gets the signed amount associated with the billing record.
        /// </summary>
        public abstract decimal SignedAmount { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
