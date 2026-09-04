using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager
{
    /// <summary>
    /// Represents a service offered by the inn, including its name, description, price, and availability status.
    /// </summary>
    /// <remarks>
    /// The Service class contains properties for storing service information such as ServiceName, Description, Price, and IsAvailable status. It is used to manage services within the inn management system.
    /// </remarks>
    public class Service
    {
        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public bool IsAvailable { get; set; } = true;
    }
}
