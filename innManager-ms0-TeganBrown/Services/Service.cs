using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Services
{
    /// <summary>
    /// Represents a service offered by the inn, including its name, description, price, and availability status.
    /// </summary>
    /// <remarks>
    /// The Service class contains properties for storing service information such as ServiceName, Description, Price, and IsAvailable status. It is used to manage services within the inn management system.
    /// </remarks>
    public class Service : INotifyPropertyChanged
    {
        private string _serviceName = string.Empty;
        private string _description = string.Empty;
        private decimal _price = decimal.Zero;
        private bool _isAvailable = true;
        private ServiceCategory _category = ServiceCategory.Miscellaneous;

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string ServiceName
        {
            get => _serviceName;
            set
            {
                if (_serviceName == value) return;
                _serviceName = value;
                OnPropertyChanged(nameof(ServiceName));
            }
        }
        /// <summary>
        /// Gets or sets the description of the service.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the price of the service.
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value) return;
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the service is currently available.
        /// </summary>
        public bool IsAvailable
        {
            get => _isAvailable;
            set
            {
                if (_isAvailable == value) return;
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
        /// <summary>
        /// Gets or sets the category of the service, represented by the ServiceCategory enum. This property allows for categorization of services into predefined categories such as Food, Beverage, Spa, etc.
        /// </summary>
        public ServiceCategory Category
        {
            get => _category;
            set
            {
                if (_category == value) return;
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
