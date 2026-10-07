using Microsoft.VisualStudio.TestPlatform.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Reservations
{
    /// <summary>
    /// Runs tests for the Reservation class in InnManager
    /// </summary>
    public class ReservationUnitTests
    {
        /// <summary>
        /// Ensures all default values are correct
        /// </summary>
        [Fact]
        public void ReservationDefaultValuesTest()
        {
            Reservation reservation = new Reservation();
            Assert.Equal(reservation.GuestName, string.Empty);
            Assert.Equal(reservation.RoomNumber, string.Empty);
            Assert.Equal(reservation.CheckInDate.Date, DateTime.Now.Date);
            Assert.Equal(reservation.CheckOutDate.Date, DateTime.Now.Date);
            Assert.False(reservation.IsCheckedOut);
            Assert.False(reservation.IsConfirmed);
            Assert.False(reservation.IsCheckoutOverdue);
            Assert.False(reservation.IsActive);
            Assert.Equal(reservation.Status, "Pending");

        }
        /// <summary>
        /// Checks if the reservation has the correct status
        /// </summary>
        /// <param name="offset">signifies the current day</param>
        /// <param name="checkedOut">signifies if the room is checked out of</param>
        /// <param name="confirmed">signifies if the room is confirmed</param>
        /// <param name="exOverdue">the expected overdue status of the reservation</param>
        /// <param name="exActive">the expected active status of the room</param>
        /// <param name="exStatus">the expected general status of the room</param>
        [Theory]
        [InlineData(1, false, false, false, false, "Pending")]
        [InlineData(1, false, true, false, true, "Confirmed")]
        [InlineData(-1, false, false, true, false, "Overdue")]
        [InlineData(-1, false, true, true, true, "Overdue")]
        [InlineData(0, false, false, false, false, "Pending")]
        [InlineData(0, false, true, false, true, "Confirmed")]
        [InlineData(-1, true, true, false, false, "Checked Out")]
        [InlineData(1, true, true, false, false, "Checked Out")]
        public void CheckReservationStatus(int offset, bool checkedOut, bool confirmed, bool exOverdue, bool exActive, string exStatus)
        {
            Reservation reservation = new Reservation();
            reservation.CheckOutDate = DateTime.Now.AddDays(offset);
            reservation.IsCheckedOut = checkedOut;
            reservation.IsConfirmed = confirmed;
            Assert.Equal(exOverdue, reservation.IsCheckoutOverdue);
            Assert.Equal(exActive, reservation.IsActive);
            Assert.Equal(exStatus, reservation.Status);
        }
    }
}
