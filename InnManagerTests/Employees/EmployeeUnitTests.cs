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
        }
    }
}
