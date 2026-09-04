using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
{
    /// <summary>
    /// Represents a reservation made by a guest for a specific room in the inn, including check-in and check-out dates, confirmation status, and checkout status.
    /// </summary>
    /// <remarks>
    /// The Reservation class contains properties for storing reservation information such as GuestName, RoomNumber, CheckInDate, CheckOutDate, IsConfirmed status, and IsCheckedOut status. It also includes computed properties to determine if the checkout is overdue, if the reservation is active, and the current status of the reservation. It is used to manage reservations within the inn management system.
    /// </remarks>
    public class Reservation
    {
        public string GuestName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; } = DateTime.Now;
        public DateTime CheckOutDate { get; set; } = DateTime.Now;
        public bool IsConfirmed { get; set; } = false;
        public bool IsCheckedOut { get; set; } = false;
        public bool IsCheckoutOverdue 
        { 
            get
            {
                return DateTime.Now > CheckOutDate && !IsCheckedOut;
            }
        }
        public bool IsActive 
        { 
            get
            {
                return IsConfirmed && !IsCheckedOut;
            }
        }
        public string Status 
        {
            get
            {
                if (IsCheckoutOverdue)
                {
                    return "Overdue";
                }
                else if (IsCheckedOut)
                {
                    return "Checked Out";
                }
                else if (IsConfirmed)
                {
                    return "Confirmed";
                }
                else
                {
                    return "Pending";
                }
            } 
        }
    }
}
