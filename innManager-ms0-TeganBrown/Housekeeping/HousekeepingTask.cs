using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Housekeeping
{
    /// <summary>
    /// Represents a housekeeping task for a specific room in the inn.
    /// </summary>
    /// <remarks>
    /// The HousekeepingTask class contains properties for storing housekeeping task information such as RoomNumber, Description, ScheduledDate, and IsCompleted status. It is used to manage housekeeping tasks within the inn management system.
    /// </remarks>
    public class HousekeepingTask : INotifyPropertyChanged
    {
        private string _roomNumber = string.Empty;
        private string _description = string.Empty;
        private DateTime _scheduledDate = DateTime.Now;
        private bool _isCompleted;
        private string _assignedStaff = string.Empty;

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (_roomNumber == value) return;
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public DateTime ScheduledDate
        {
            get => _scheduledDate;
            set
            {
                if (_scheduledDate == value) return;
                _scheduledDate = value;
                OnPropertyChanged(nameof(ScheduledDate));
            }
        }
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted == value) return;
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
                OnPropertyChanged(nameof(Status));
            }
        }
        public string Status
        {
            get => IsCompleted ? "Completed" : "Not Completed";
            set
            {
                if (value == "Completed" || value == "Complete")
                {
                    IsCompleted = true;
                }
                else if (value == "Not Completed" || value == "Not Complete")
                {
                    IsCompleted = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets the name of the staff member assigned to the housekeeping task.
        /// </summary>
        public string AssignedStaff
        {
            get => _assignedStaff;
            set
            {
                if (_assignedStaff == value) return;
                _assignedStaff = value;
                OnPropertyChanged(nameof(AssignedStaff));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
