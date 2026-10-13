using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Employees
{
    /// <summary>
    /// Represents an employee in the inn management system.
    /// </summary>
    /// <remarks>
    /// The Employee class contains properties for storing employee information such as EmployeeID, FirstName, LastName, Position, and IsActive status. It is used to manage employee records within the inn management system.
    /// </remarks>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee. 
        /// </summary>
        public string EmployeeID { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the position of the employee within the inn management system. The position is represented by the EmployeePosition enum, which includes roles such as Manager, FrontDesk, Housekeeper, Maintenance, and Concierge.
        /// </summary>
        public EmployeePosition Position { get; set; } = EmployeePosition.FrontDesk;
        /// <summary>
        /// Gets or sets a value indicating whether the employee is currently active.
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the hire date of the employee.
        /// </summary>
        public DateTime HireDate { get; set; } = DateTime.Now;
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
    }
}
