using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    public class BillingSummary : IEnumerable<IBillingRecord>
    {
        public BillingSummary(IEnumerable<IBillingRecord> records)
        {
            _records = records;
        }

        decimal TotalCharges 
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

        decimal TotalPayments 
        {
            get
            {
                decimal total = 0;
                foreach (var record in _records)
                {
                    if (record is Payment && record.IsProcessed != false)
                    {
                        total += record.Amount;
                    }
                }
                return total;
            }
        }

        decimal NetBalance 
        {
            get
            {
                return TotalCharges - TotalPayments;
            }
        }

        // Implement IEnumerable<IBillingRecord>
        public IEnumerator<IBillingRecord> GetEnumerator()
        {
            return _records.GetEnumerator();
        }

        // Implement non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private readonly IEnumerable<IBillingRecord> _records;
    }
}
