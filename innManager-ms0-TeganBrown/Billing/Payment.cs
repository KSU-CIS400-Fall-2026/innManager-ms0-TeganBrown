using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a payment record in the billing system, inheriting from the BillingRecord class. This class includes properties for the payment method and overrides the SignedAmount property to reflect the negative value of the payment amount.
    /// </summary>
    public class Payment : BillingRecord
    {
        private PaymentMethod _paymentMethod = PaymentMethod.Cash;
        private string _refrenceNumber = string.Empty;

        /// <summary>
        /// Gets or sets the method of payment used for the transaction, represented by the PaymentMethod enum. This property allows for specifying whether the payment was made via cash, credit card, debit card, or other methods.
        /// </summary>
        public PaymentMethod PaymentMethod
        {
            get => _paymentMethod;
            set
            {
                if (_paymentMethod == value) return;
                _paymentMethod = value;
                OnPropertyChanged(nameof(PaymentMethod));
            }
        }
        /// <summary>
        /// Gets the signed amount associated with the payment record. For payments, this value is negative, indicating a reduction in the total amount owed by the guest.
        /// </summary>
        public override decimal SignedAmount => -Amount;
        /// <summary>
        /// Gets or sets the reference number associated with the payment transaction.
        /// </summary>
        public string RefrenceNumber
        {
            get => _refrenceNumber;
            set
            {
                if (_refrenceNumber == value) return;
                _refrenceNumber = value;
                OnPropertyChanged(nameof(RefrenceNumber));
            }
        }

        private bool _isRefunded = false;

        public bool IsRefunded
        {
            get => _isRefunded;
            set
            {
                if (_isRefunded == value) return;
                _isRefunded = value;
                OnPropertyChanged(nameof(IsRefunded));
            }
        }
    }
}
