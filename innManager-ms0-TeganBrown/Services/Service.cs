using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Services
{
    /// <summary>
    /// Represents a service offered by the inn, including its name, description, price, and availability status.
    /// </summary>
    /// <remarks>
    /// The Service class contains properties for storing service information such as ServiceName, Description, Price, and IsAvailable status. It is used to manage services within the inn management system.
    /// </remarks>
    public class Service
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the description of the service.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        public decimal Price { get; set; } = decimal.Zero;
        /// <summary>
        /// Gets or sets a value indicating whether the service is currently available.
        /// </summary>
        public bool IsAvailable { get; set; } = true;
        /// <summary>
        /// Gets or sets the category of the service, represented by the ServiceCategory enum. This property allows for categorization of services into predefined categories such as Food, Beverage, Spa, etc.
        /// </summary>
        public ServiceCategory Category { get; set; } = ServiceCategory.Miscellaneous;
    }
}
