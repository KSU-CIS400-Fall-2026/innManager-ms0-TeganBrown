using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Housekeeping
{
    /// <summary>
    /// Represents a housekeeping task for a specific room in the inn.
    /// </summary>
    /// <remarks>
    /// The HousekeepingTask class contains properties for storing housekeeping task information such as RoomNumber, Description, ScheduledDate, and IsCompleted status. It is used to manage housekeeping tasks within the inn management system.
    /// </remarks>
    public class HousekeepingTask
    {
        public string RoomNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;
        public string Status 
        {
            get
            {
                if (IsCompleted)
                {
                    return "Completed";
                }
                else
                {
                    return "Not Completed";
                }
            } 
        }
    }
}
