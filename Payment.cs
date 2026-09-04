using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
{
    /// <summary>
    /// Represents a payment made by a guest for their stay at the inn, including the amount, payment date, payment method, and success status.
    /// </summary>
    /// <remarks>
    /// The Payment class contains properties for storing payment information such as Amount, PaymentDate, PaymentMethod, and IsSuccessful status. It is used to manage payments within the inn management system.
    /// </remarks>
    public class Payment
    {
        public decimal Amount { get; set; } = decimal.Zero;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; } = false;
    }
}
