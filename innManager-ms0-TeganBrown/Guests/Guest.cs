using System;
using System.Collections.Generic;
using System.Text;
using InnManager.Enums;

namespace InnManager.Guests
{
    /// <summary>
    /// Represents a guest staying at the inn, including their personal information and check-in status.
    /// </summary>
    /// <remarks>
    /// The Guest class contains properties for storing guest information. It is used to manage guest records within the inn management system.
    /// </remarks>
    public class Guest
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsCheckedIn { get; set; } = false;
        /// <summary>
        /// Gets or sets the unique identifier for the guest.
        /// </summary>
        public string GuestID { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the address of the guest.
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the type of identification provided by the guest.
        /// </summary>
        public IDType IDType { get; set; } = IDType.Other;
        /// <summary>
        /// Gets or sets the identification number of the guest.
        /// </summary>
        public string IDNumber { get; set; } = string.Empty;
    }
}
