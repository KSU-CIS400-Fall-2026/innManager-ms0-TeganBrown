using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Employees
{
    /// <summary>
    /// Runs tests for the Employee class in InnManager
    /// </summary>
    public class EmployeeUnitTests
    {
        /// <summary>
        /// Ensures that default values are correct
        /// </summary>
        [Fact]
        public void EmployeeDefaultValuesTests()
        {
            Employee employee = new Employee();
            Assert.Equal(employee.EmployeeID, string.Empty);
            Assert.Equal(employee.FirstName, string.Empty);
            Assert.Equal(employee.LastName, string.Empty);
            Assert.Equal(employee.Position, EmployeePosition.FrontDesk);
            Assert.True(employee.IsActive);
            Assert.Equal(string.Empty, employee.Email);
            Assert.Equal(string.Empty, employee.PhoneNumber);
            Assert.Equal(DateTime.Now.Date, employee.HireDate.Date);
        }
        /// <summary>
        /// Ensures that the employee status is correctly updated based on their active status
        /// </summary>
        [Fact]
        public void EmployeeStatusTest()
        {
            Employee employee = new Employee();
            Assert.Equal(employee.Status, "Active");
            employee.IsActive = false;
            Assert.Equal(employee.Status, "Inactive");
        }
    }
}
