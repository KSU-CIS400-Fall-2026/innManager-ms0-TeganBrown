using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Guests
{
    /// <summary>
    /// Runs tests for the Guest class in InnManager
    /// </summary>
    public class GuestUnitTests
    {
        /// <summary>
        /// Ensures all default values are correct
        /// </summary>
        [Fact]
        public void GuestDefaultValuesTest()
        {
            Guest guest = new Guest();
            Assert.Equal(guest.FirstName, string.Empty);
            Assert.Equal(guest.LastName, string.Empty);
            Assert.Equal(guest.Email, string.Empty);
            Assert.Equal(guest.PhoneNumber, string.Empty);
            Assert.False(guest.IsCheckedIn);
            Assert.Equal(string.Empty, guest.GuestID);
            Assert.Equal(string.Empty, guest.Address);
            Assert.Equal(IDType.Other, guest.IDType);
            Assert.Equal(string.Empty, guest.IDNumber);
        }
    }
}
