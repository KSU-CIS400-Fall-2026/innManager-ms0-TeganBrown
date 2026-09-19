using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents an invoice for a guest's stay at the inn.
    /// </summary>
    /// <remarks>
    /// The Invoice class contains properties for storing invoice information such as GuestName, RoomNumber, RoomCharge, and ServiceCharge. It is used to manage invoices within the inn management system.
    /// </remarks>
    public class Invoice 
    {
        public string GuestName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public List<BillingRecord> BillingRecords { get; } = new();
        public decimal TotalCharges => BillingRecords.OfType<Charge>().Sum(c => c.Amount);
        public decimal TotalPayments => BillingRecords.OfType<Payment>().Sum(p => p.Amount);
        public decimal BalanceDue => TotalCharges - TotalPayments;
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


    }
}
