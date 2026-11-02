using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Guests
{
    /// <summary>
    /// Represents a guest staying at the inn, including their personal information and check-in status.
    /// </summary>
    /// <remarks>
    /// The Guest class contains properties for storing guest information. It is used to manage guest records within the inn management system.
    /// </remarks>
    public class Guest : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;
        private bool _isCheckedIn;
        private string _guestID = string.Empty;
        private string _address = string.Empty;
        private IDType _idType = IDType.Other;
        private string _idNumber = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value) return;
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber == value) return;
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public bool IsCheckedIn
        {
            get => _isCheckedIn;
            set
            {
                if (_isCheckedIn == value) return;
                _isCheckedIn = value;
                OnPropertyChanged(nameof(IsCheckedIn));
            }
        }
        /// <summary>
        /// Gets or sets the unique identifier for the guest.
        /// </summary>
        public string GuestID
        {
            get => _guestID;
            set
            {
                if (_guestID == value) return;
                _guestID = value;
                OnPropertyChanged(nameof(GuestID));
            }
        }
        /// <summary>
        /// Gets or sets the address of the guest.
        /// </summary>
        public string Address
        {
            get => _address;
            set
            {
                if (_address == value) return;
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        /// <summary>
        /// Gets or sets the type of identification provided by the guest.
        /// </summary>
        public IDType IDType
        {
            get => _idType;
            set
            {
                if (_idType == value) return;
                _idType = value;
                OnPropertyChanged(nameof(IDType));
            }
        }
        /// <summary>
        /// Gets or sets the identification number of the guest.
        /// </summary>
        public string IDNumber
        {
            get => _idNumber;
            set
            {
                if (_idNumber == value) return;
                _idNumber = value;
                OnPropertyChanged(nameof(IDNumber));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => $"{LastName}, {FirstName}";
    }
}
