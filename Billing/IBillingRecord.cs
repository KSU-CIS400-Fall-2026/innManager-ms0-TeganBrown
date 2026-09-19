using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a billing record with properties for amount, date, processing status, and signed amount.
    /// </summary>
    public interface IBillingRecord
    {
        /// <summary>
        /// Gets the amount associated with the billing record.
        /// </summary>
        decimal Amount { get; }
        /// <summary>
        /// Gets the date of the billing record.
        /// </summary>
        DateTime date { get; }
        /// <summary>
        /// Gets a value indicating whether the billing record has been processed.
        /// </summary>
        bool IsProcessed { get; }
        /// <summary>
        /// Gets the signed amount associated with the billing record.
        /// </summary>
        decimal SignedAmount { get; }
    }
}
