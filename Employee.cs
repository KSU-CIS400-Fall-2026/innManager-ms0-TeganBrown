using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
{
    /// <summary>
    /// Represents an employee in the inn management system.
    /// </summary>
    /// <remarks>
    /// The Employee class contains properties for storing employee information such as EmployeeID, FirstName, LastName, Position, and IsActive status. It is used to manage employee records within the inn management system.
    /// </remarks>
    public class Employee
    {
        public string EmployeeID { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
