using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Services
{
    /// <summary>
    /// Runs tests for the Service Class in InnManager
    /// </summary>
    public class ServiceUnitTests
    {
        /// <summary>
        /// Ensures all default values are correct
        /// </summary>
        [Fact]
        public void ServiceDefaultValuesTests()
        {
            Service service = new Service();
            Assert.Equal(service.ServiceName, string.Empty);
            Assert.Equal(service.Description, string.Empty);
            Assert.Equal(service.Price, decimal.Zero);
            Assert.True(service.IsAvailable);
            Assert.Equal(service.Category, ServiceCategory.Miscellaneous);
        }
    }
}
