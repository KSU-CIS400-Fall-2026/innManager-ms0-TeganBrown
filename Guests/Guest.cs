using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Guests
{
    /// <summary>
    /// Represents a guest staying at the inn, including their personal information and check-in status.
    /// </summary>
    /// <remarks>
    /// The Guest class contains properties for storing guest information such as FirstName, LastName, Email, PhoneNumber, and IsCheckedIn status. It is used to manage guest records within the inn management system.
    /// </remarks>
    public class Guest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsCheckedIn { get; set; } = false;
    }
}
