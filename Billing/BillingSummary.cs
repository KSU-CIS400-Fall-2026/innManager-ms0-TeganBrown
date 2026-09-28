using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a summary of billing records, providing methods to calculate total charges, total payments, and net balance.
    /// </summary>
    public class BillingSummary : IEnumerable<IBillingRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingSummary"/> class with the specified billing records.
        /// </summary>
        /// <param name="records"></param>
        public BillingSummary(IEnumerable<IBillingRecord> records)
        {
            _records = records;
        }
        /// <summary>
        /// Gets the total charges from the billing records.
        /// </summary>
        public decimal TotalCharges 
        {
            get
            {
                decimal total = 0;
                foreach (var record in _records)
                {
                    if (record is Charge && record.IsProcessed != false)
                    {
                        total += record.Amount;
                    }
                }
                return total;
            }
        }
        /// <summary>
        /// Gets the total payments from the billing records.
        /// </summary>
        public decimal TotalPayments 
        {
            get
            {
                decimal total = 0;
                foreach (var record in _records)
                {
                    if (record is Payment && record.IsProcessed)
                    {
                        total += record.Amount;
                    }
                }
                return total;
            }
        }
        /// <summary>
        /// Gets the net balance, calculated as the difference between total charges and total payments.
        /// </summary>
        public decimal NetBalance 
        {
            get
            {
                return TotalCharges - TotalPayments;
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through the collection of billing records.
        /// </summary>
        /// <returns>an enumerator</returns>
        public IEnumerator<IBillingRecord> GetEnumerator()
        {
            return _records.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of billing records.
        /// </summary>
        /// <returns>an enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// The collection of billing records included in the summary.
        /// </summary>
        private readonly IEnumerable<IBillingRecord> _records;
    }
}
