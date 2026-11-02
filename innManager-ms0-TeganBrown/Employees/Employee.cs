using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Employees
{
    /// <summary>
    /// Represents an employee in the inn management system.
    /// </summary>
    /// <remarks>
    /// The Employee class contains properties for storing employee information such as EmployeeID, FirstName, LastName, Position, and IsActive status. It is used to manage employee records within the inn management system.
    /// </remarks>
    public class Employee : INotifyPropertyChanged
    {
        private string _employeeID = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private EmployeePosition _position = EmployeePosition.FrontDesk;
        private bool _isActive = true;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;
        private DateTime _hireDate = DateTime.Now;

        /// <summary>
        /// Gets or sets the unique identifier for the employee. 
        /// </summary>
        public string EmployeeID
        {
            get => _employeeID;
            set
            {
                if (_employeeID == value) return;
                _employeeID = value;
                OnPropertyChanged(nameof(EmployeeID));
            }
        }
        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the position of the employee within the inn management system. The position is represented by the EmployeePosition enum, which includes roles such as Manager, FrontDesk, Housekeeper, Maintenance, and Concierge.
        /// </summary>
        public EmployeePosition Position
        {
            get => _position;
            set
            {
                if (_position == value) return;
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the employee is currently active.
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the hire date of the employee.
        /// </summary>
        public DateTime HireDate
        {
            get => _hireDate;
            set
            {
                if (_hireDate == value) return;
                _hireDate = value;
                OnPropertyChanged(nameof(HireDate));
            }
        }
        /// <summary>
        /// Gets or sets the Status of the employee.
        /// </summary>
        public string Status
        {
            get
            {
                if (IsActive) return "Active";
                else return "Inactive";
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
