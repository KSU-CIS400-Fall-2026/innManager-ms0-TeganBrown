using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a billing record with properties for amount, date, description, processing status, and signed amount.
    /// </summary>
    public abstract class BillingRecord : IBillingRecord
    {
        /// <summary>
        /// Gets or sets the amount associated with the billing record.
        /// </summary>
        public decimal Amount { get; set; } = decimal.Zero;
        /// <summary>
        /// Gets or sets the date of the billing record.
        /// </summary>
        public DateTime date { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the description of the billing record.
        /// </summary>
        public string Description { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether the billing record has been processed.
        /// </summary>
        public bool IsProcessed { get; set; } = false;
        /// <summary>
        /// Gets the signed amount associated with the billing record.
        /// </summary>
        public abstract decimal SignedAmount { get; }
    }
}
