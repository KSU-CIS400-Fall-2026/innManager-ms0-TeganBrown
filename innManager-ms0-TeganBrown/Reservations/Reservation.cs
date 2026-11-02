using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using InnManager.Rooms;

namespace InnManager.Reservations
{
    /// <summary>
    /// Represents a reservation made by a guest for a specific room in the inn, including check-in and check-out dates, confirmation status, and checkout status.
    /// </summary>
    /// <remarks>
    /// The Reservation class contains properties for storing reservation information such as GuestName, RoomNumber, CheckInDate, CheckOutDate, IsConfirmed status, and IsCheckedOut status. It also includes computed properties to determine if the checkout is overdue, if the reservation is active, and the current status of the reservation. It is used to manage reservations within the inn management system.
    /// </remarks>
    public class Reservation : INotifyPropertyChanged
    {
        private string _guestName = string.Empty;
        private int _numberOfGuests = 1;
        private Room _room;
        private DateTime _checkInDate = DateTime.Now;
        private DateTime _checkOutDate = DateTime.Now;
        private bool _isConfirmed;
        private bool _isCheckedOut;
        private string _reservationNumber = string.Empty;

        /// <summary>
        /// Gets or sets the name of the guest who made the reservation.
        /// </summary>
        public string GuestName
        {
            get => _guestName;
            set
            {
                if (_guestName == value) return;
                _guestName = value;
                OnPropertyChanged(nameof(GuestName));
            }
        }
        /// <summary>
        /// Gets or sets the number of guests included in the reservation.
        /// </summary>
        public int NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                if (_numberOfGuests == value) return;
                _numberOfGuests = value;
                OnPropertyChanged(nameof(NumberOfGuests));
            }
        }
        /// <summary>
        /// Gets or sets the room number associated with the reservation.
        /// </summary>
        public Room Room
        {
            get => _room;
            set
            {
                if (_room == value) return;
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
        /// <summary>
        /// Gets or sets the check-in date for the reservation.
        /// </summary>
        public DateTime CheckInDate
        {
            get => _checkInDate;
            set
            {
                if (_checkInDate == value) return;
                _checkInDate = value;
                OnPropertyChanged(nameof(CheckInDate));
            }
        }
        /// <summary>
        /// Gets or sets the check-out date for the reservation.
        /// </summary>
        public DateTime CheckOutDate
        {
            get => _checkOutDate;
            set
            {
                if (_checkOutDate == value) return;
                _checkOutDate = value;
                OnPropertyChanged(nameof(CheckOutDate));
                OnPropertyChanged(nameof(IsCheckoutOverdue));
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the reservation has been confirmed by the inn management system.
        /// </summary>
        public bool IsConfirmed
        {
            get => _isConfirmed;
            set
            {
                if (_isConfirmed == value) return;
                _isConfirmed = value;
                OnPropertyChanged(nameof(IsConfirmed));
                OnPropertyChanged(nameof(IsActive));
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the guest has checked out of the room associated with the reservation.
        /// </summary>
        public bool IsCheckedOut
        {
            get => _isCheckedOut;
            set
            {
                if (_isCheckedOut == value) return;
                _isCheckedOut = value;
                OnPropertyChanged(nameof(IsCheckedOut));
                OnPropertyChanged(nameof(IsCheckoutOverdue));
                OnPropertyChanged(nameof(IsActive));
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Gets a value indicating whether the checkout date for the reservation has passed and the guest has not yet checked out. This property is computed based on the current date and time, the check-out date, and the IsCheckedOut status.
        /// </summary>
        public bool IsCheckoutOverdue 
        { 
            get
            {
                return DateTime.Now.Date > CheckOutDate.Date && !IsCheckedOut;
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
        private string _status = "Pending";
        /// <summary>
        /// Gets the current status of the reservation as a string. The status is determined based on the IsCheckoutOverdue, IsCheckedOut, and IsConfirmed properties. Possible status values include "Overdue", "Checked Out", "Confirmed", and "Pending".
        /// </summary>
        public string Status 
        {
            get => _status;

            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Gets or sets the reservation number.
        /// </summary>
        public string ReservationNumber
        {
            get => _reservationNumber;
            set
            {
                if (_reservationNumber == value) return;
                _reservationNumber = value;
                OnPropertyChanged(nameof(ReservationNumber));
            }
        }

        public override string ToString() => $"{Room.roomNumber}: {GuestName}";

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
