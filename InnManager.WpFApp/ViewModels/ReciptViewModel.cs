using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.WpFApp.ViewModels
{
    public class ReciptViewModel
    {

        public string HotelName { get; set; }

        public string PaymentRef { get; set; }

        public string InvoiceNum { get; set; }

        public string GuestName { get; set; }

        public string RoomNum { get; set; }

        public decimal InvoiceTotal { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal RemainingBalance => InvoiceTotal - AmountPaid;

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string Status => RemainingBalance <= 0 ? "Completed" : "Incomplete";

        public ReciptViewModel(string hotelName, string paymentRef, string invoiceNum, string guestName, string roomNum, decimal invoiceTotal, decimal amountPaid, DateTime paymentDate, PaymentMethod paymentMethod)
        {
            HotelName = hotelName;
            PaymentRef = paymentRef;
            InvoiceNum = invoiceNum;
            GuestName = guestName;
            RoomNum = roomNum;
            InvoiceTotal = invoiceTotal;
            AmountPaid = amountPaid;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }
    }
}
