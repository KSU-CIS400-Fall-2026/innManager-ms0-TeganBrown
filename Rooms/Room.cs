using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Rooms
{
    /// <summary>
    /// Represents a hotel room managed by the InnManager system.
    /// </summary>
    /// <remarks>
    /// The Room class stores identifying information about a hotel room, including its room number, room type, nightly rate and current availability.
    /// </remarks>
    public class Room
    {
        private static long _nextID = 0;

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
        long roomID { get; set; } = nextID;
        /// <summary>
        /// Gets or sets the room number, which uniquely identifies the room within the hotel.
        /// </summary>
        public string roomNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the type of the room, represented by the RoomType enum. This property allows for categorization of rooms into predefined types such as Standard, Deluxe, Suite, etc.
        /// </summary>
        public RoomType roomType { get; set; } = RoomType.Standard;
        /// <summary>
        /// Gets or sets a value indicating whether the room is currently available for booking.
        public bool isAvailable { get; set; } = true;
        /// <summary>
        /// Gets or sets the nightly rate for the room, which represents the cost of booking the room for one night.
        /// </summary>
        public decimal NightlyRate { get; set; } = 0m;
        /// <summary>
        /// Gets or sets the floor number on which the room is located within the hotel.
        /// </summary>
        int Floor { get; set; } = 0;
        /// <summary>
        /// Gets or sets the capacity of the room, which indicates the maximum number of guests that can be accommodated in the room.
        /// </summary>
        int Capacity { get; set; } = 0;
        /// <summary>
        /// Gets or sets a value indicating whether the room has a balcony.
        /// </summary>
        bool HasBalcony { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether the room is clean.
        /// </summary>
        bool IsClean { get; set; } = true;
        /// <summary>
        /// Gets or sets the status of the room, represented by the RoomStatus enum.
        /// </summary>
        RoomStatus Status { get; set; } = RoomStatus.Available;
    }
}