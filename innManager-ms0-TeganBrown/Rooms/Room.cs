using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Rooms
{
    /// <summary>
    /// Represents a hotel room managed by the InnManager system.
    /// </summary>
    /// <remarks>
    /// The Room class stores identifying information about a hotel room, including its room number, room type, nightly rate and current availability.
    /// </remarks>
    public class Room : INotifyPropertyChanged
    {
        private static long _nextID = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public static long nextID
        {
            get
            {
                _nextID++;          // Step 1: increment the ID
                return _nextID;     // Step 2: return the new value
            }
        }
        /// <summary>
        /// Gets or sets the unique identifier for the room.
        /// </summary>
        private readonly long _roomID = nextID;
        private long roomID => _roomID;
        private string _roomNumber = string.Empty;
        private RoomType _roomType = RoomType.Standard;
        private bool _isAvailable = true;
        private decimal _nightlyRate;
        private int _floor;
        private int _capacity = 1;
        private bool _hasBalcony;
        private bool _isClean = true;
        private RoomStatus _status = RoomStatus.Available;

        /// <summary>
        /// Gets or sets the room number, which uniquely identifies the room within the hotel.
        /// </summary>
        public string roomNumber
        {
            get => _roomNumber;
            set
            {
                if (_roomNumber == value) return;
                _roomNumber = value;
                OnPropertyChanged(nameof(roomNumber));
            }
        }
        /// <summary>
        /// Gets or sets the type of the room, represented by the RoomType enum. This property allows for categorization of rooms into predefined types such as Standard, Deluxe, Suite, etc.
        /// </summary>
        public RoomType roomType
        {
            get => _roomType;
            set
            {
                if (_roomType == value) return;
                _roomType = value;
                OnPropertyChanged(nameof(roomType));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the room is currently available for booking.
        public bool isAvailable
        {
            get => _isAvailable;
            set
            {
                if (_isAvailable == value) return;
                _isAvailable = value;
                OnPropertyChanged(nameof(isAvailable));
            }
        }
        /// <summary>
        /// Gets or sets the nightly rate for the room, which represents the cost of booking the room for one night.
        /// </summary>
        public decimal NightlyRate
        {
            get => _nightlyRate;
            set
            {
                if (_nightlyRate == value) return;
                _nightlyRate = value;
                OnPropertyChanged(nameof(NightlyRate));
            }
        }
        /// <summary>
        /// Gets or sets the floor number on which the room is located within the hotel.
        /// </summary>
        public int Floor
        {
            get => _floor;
            set
            {
                if (_floor == value) return;
                _floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }
        /// <summary>
        /// Gets or sets the capacity of the room, which indicates the maximum number of guests that can be accommodated in the room.
        /// </summary>
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (_capacity == value) return;
                _capacity = value;
                OnPropertyChanged(nameof(Capacity));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the room has a balcony.
        /// </summary>
        public bool HasBalcony
        {
            get => _hasBalcony;
            set
            {
                if (_hasBalcony == value) return;
                _hasBalcony = value;
                OnPropertyChanged(nameof(HasBalcony));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the room is clean.
        /// </summary>
        public bool IsClean
        {
            get => _isClean;
            set
            {
                if (_isClean == value) return;
                _isClean = value;
                OnPropertyChanged(nameof(IsClean));
            }
        }
        /// <summary>
        /// Gets or sets the status of the room, represented by the RoomStatus enum.
        /// </summary>
        public RoomStatus Status
        {
            get => _status;
            set
            {
                if (_status == value) return;
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public override string ToString() => $"{roomNumber}";

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}