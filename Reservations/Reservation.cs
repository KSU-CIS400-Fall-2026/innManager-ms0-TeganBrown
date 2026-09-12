using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Reservations
{
    /// <summary>
    /// Represents a reservation made by a guest for a specific room in the inn, including check-in and check-out dates, confirmation status, and checkout status.
    /// </summary>
    /// <remarks>
    /// The Reservation class contains properties for storing reservation information such as GuestName, RoomNumber, CheckInDate, CheckOutDate, IsConfirmed status, and IsCheckedOut status. It also includes computed properties to determine if the checkout is overdue, if the reservation is active, and the current status of the reservation. It is used to manage reservations within the inn management system.
    /// </remarks>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets the name of the guest who made the reservation.
        /// </summary>
        public string GuestName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the room number associated with the reservation.
        /// </summary>
        public string RoomNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the check-in date for the reservation.
        /// </summary>
        public DateTime CheckInDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the check-out date for the reservation.
        /// </summary>
        public DateTime CheckOutDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets a value indicating whether the reservation has been confirmed by the inn management system.
        /// </summary>
        public bool IsConfirmed { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether the guest has checked out of the room associated with the reservation.
        /// </summary>
        public bool IsCheckedOut { get; set; } = false;
        /// <summary>
        /// Gets a value indicating whether the checkout date for the reservation has passed and the guest has not yet checked out. This property is computed based on the current date and time, the check-out date, and the IsCheckedOut status.
        /// </summary>
        public bool IsCheckoutOverdue 
        { 
            get
            {
                return DateTime.Now > CheckOutDate && !IsCheckedOut;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the reservation is currently active. A reservation is considered active if it has been confirmed and the guest has not yet checked out. This property is computed based on the IsConfirmed and IsCheckedOut statuses.
        /// </summary>
        public bool IsActive 
        { 
            get
            {
                return IsConfirmed && !IsCheckedOut;
            }
        }
        /// <summary>
        /// Gets the current status of the reservation as a string. The status is determined based on the IsCheckoutOverdue, IsCheckedOut, and IsConfirmed properties. Possible status values include "Overdue", "Checked Out", "Confirmed", and "Pending".
        /// </summary>
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
