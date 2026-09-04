using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
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
        public decimal RoomCharge { get; set; } = decimal.Zero;
        public decimal ServiceCharge { get; set; } = decimal.Zero;
        public bool IsPaid { get; set; } = false;
        public decimal TotalAmount 
        {
            get
            {
                return RoomCharge + ServiceCharge;
            } 
        }
        public string Status 
        {
            get
            {
                if (IsPaid)
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
