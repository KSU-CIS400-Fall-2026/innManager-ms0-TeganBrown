using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a payment made by a guest for their stay at the inn, including the amount, payment date, payment method, and success status.
    /// </summary>
    /// <remarks>
    /// The Payment class contains properties for storing payment information such as Amount, PaymentDate, PaymentMethod, and IsSuccessful status. It is used to manage payments within the inn management system.
    /// </remarks>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the amount of the payment.
        /// </summary>
        public decimal Amount { get; set; } = decimal.Zero;
        /// <summary>
        /// Gets or sets the date and time when the payment was made.
        /// </summary>
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the method of payment used for the transaction, represented by the PaymentMethod enum. This property allows for specifying whether the payment was made via cash, credit card, debit card, or other methods.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        /// <summary>
        /// Gets or sets a value indicating whether the payment was successful.
        /// </summary>
        public bool IsSuccessful { get; set; } = false;

    }
}
