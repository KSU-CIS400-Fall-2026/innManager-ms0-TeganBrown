using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
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
        long roomID { get; set; } = nextID;
        public string roomNumber { get; set; } = string.Empty;
        public string roomType { get; set; } = string.Empty;
        public bool isAvailable { get; set; } = true;

        public decimal NightlyRate { get; set; } = 0m;

        int Floor { get; set; } = 0;
        int Capacity { get; set; } = 0;
        bool HasBalcony { get; set; } = false;
        bool IsClean { get; set; } = true;
        string Status { get; set; } = "Available";
    }
}