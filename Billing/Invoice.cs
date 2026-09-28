using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Gets or sets the name of the guest associated with the invoice.
        /// </summary>
        public string GuestName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the room number associated with the invoice.
        /// </summary>
        public string RoomNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets the list of billing records associated with the invoice.
        /// </summary>
        public List<BillingRecord> BillingRecords { get; } = new();
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


    }
}
