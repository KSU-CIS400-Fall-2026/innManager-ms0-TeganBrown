using InnManager.Billing;
using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Rooms;
using System;
using System.Linq;

namespace InnManager.WpFApp.ViewModels
{
    /// <summary>
    /// Provides calculated totals and counts for the hotel's reports.
    /// </summary>
    public sealed class HotelReportViewModel
    {
        private readonly Hotel _hotel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelReportViewModel"/> class.
        /// </summary>
        /// <param name="hotel">The hotel whose data is summarized in the reports.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hotel"/> is null.</exception>
        public HotelReportViewModel(Hotel hotel)
        {
            _hotel = hotel ?? throw new ArgumentNullException(nameof(hotel));
        }

        #region Properties
        /// <summary>
        /// Gets the total number of rooms in the hotel.
        /// </summary>
        public int TotalRooms
        {
            get
            {
                return _hotel.Rooms.Count;
            }
        }

        /// <summary>
        /// Gets the number of available rooms in the hotel.
        /// </summary>
        public int AvailableRoomCount
        {
            get
            {
                int count = 0;
                foreach (Room room in _hotel.Rooms)
                {
                    if (room.Status == RoomStatus.Available)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the count of occupied rooms in the hotel.
        /// </summary>
        public int OccupiedRoomCount
        {
            get
            {
                int count = 0;
                foreach (Room room in _hotel.Rooms)
                {
                    if (room.Status == RoomStatus.Occupied)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the proportion of rooms currently occupied.
        /// </summary>
        /// <remarks>
        /// The value is calculated by dividing the number of occupied rooms by the total number
        /// of rooms. A value of 0 indicates there are no rooms.
        /// </remarks>
        public double OccupancyRate
        {
            get
            {
                if (TotalRooms == 0) return 0;
                return (double)OccupiedRoomCount / TotalRooms;
            }
        }

        /// <summary>
        /// Gets the total number of guests in the hotel.
        /// </summary>
        public int TotalGuests
        {
            get
            {
                return _hotel.Guests.Count;
            }
        }

        /// <summary>
        /// Gets the number of guests currently checked in.
        /// </summary>
        public int CheckedInGuests
        {
            get
            {
                int count = 0;
                foreach (Guest guest in _hotel.Guests)
                {
                    if (guest.IsCheckedIn)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the number of guests who are not checked in.
        /// </summary>
        public int NotCheckedInGuests
        {
            get
            {
                int count = 0;
                foreach (Guest guest in _hotel.Guests)
                {
                    if (!guest.IsCheckedIn)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the total number of reservations in the hotel.
        /// </summary>
        public int TotalReservations
        {
            get
            {
                return _hotel.Reservations.Count;
            }
        }

        /// <summary>
        /// Gets the number of reservations that have been checked out.
        /// </summary>
        public int CheckedOutReservations
        {
            get
            {
                return _hotel.Reservations.Count(reservation => reservation.Status == "CheckedOut");
            }
        }

        /// <summary>
        /// Gets the number of overdue reservations.
        /// </summary>
        public int OverdueReservations
        {
            get
            {
                return _hotel.Reservations.Count(reservation => reservation.Status == "Overdue");
            }
        }

        /// <summary>
        /// Gets the number of confirmed reservations.
        /// </summary>
        public int ConfirmedReservations
        {
            get
            {
                return _hotel.Reservations.Count(reservation => reservation.Status == "Confirmed");
            }
        }

        /// <summary>
        /// Gets the number of pending reservations.
        /// </summary>
        public int PendingReservations
        {
            get
            {
                return _hotel.Reservations.Count(reservation => reservation.Status == "Pending");
            }
        }

        /// <summary>
        /// Gets the number of cancelled reservations.
        /// </summary>
        public int CancelledReservations
        {
            get
            {
                return _hotel.Reservations.Count(reservation => reservation.Status == "Cancelled");
            }
        }

        /// <summary>
        /// Gets the total number of housekeeping tasks in the hotel.
        /// </summary>
        public int TotalHousekeepingTasks
        {
            get
            {
                return _hotel.HousekeepingTasks.Count;
            }
        }

        /// <summary>
        /// Gets the number of housekeeping tasks that are not completed.
        /// </summary>
        public int InProgressHousekeepingTasks
        {
            get
            {
                int count = 0;
                foreach (HousekeepingTask task in _hotel.HousekeepingTasks)
                {
                    if (task.Status == "Not Completed")
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the number of completed housekeeping tasks.
        /// </summary>
        public int CompletedHousekeepingTasks
        {
            get
            {
                int count = 0;
                foreach (HousekeepingTask task in _hotel.HousekeepingTasks)
                {
                    if (task.Status == "Completed")
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the total number of employees in the hotel.
        /// </summary>
        public int TotalEmployees
        {
            get
            {
                return _hotel.Employees.Count;
            }
        }

        /// <summary>
        /// Gets the number of active employees.
        /// </summary>
        public int ActiveEmployees
        {
            get
            {
                int count = 0;
                foreach (Employee employee in _hotel.Employees)
                {
                    if (employee.IsActive)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the number of inactive employees.
        /// </summary>
        public int InactiveEmployees
        {
            get
            {
                int count = 0;
                foreach (Employee employee in _hotel.Employees)
                {
                    if (!employee.IsActive)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Gets total processed room charges across all invoices.
        /// </summary>
        public decimal TotalRoomCharges
        {
            get
            {
                return _hotel.Invoices
                    .SelectMany(invoice => invoice.BillingRecords.OfType<Charge>())
                    .Where(charge => charge.IsProcessed && charge.Category == ChargeCategory.Room)
                    .Sum(charge => charge.Amount);
            }
        }

        /// <summary>
        /// Gets total processed non-room charges across all invoices.
        /// </summary>
        public decimal TotalServiceCharges
        {
            get
            {
                return _hotel.Invoices
                    .SelectMany(invoice => invoice.BillingRecords.OfType<Charge>())
                    .Where(charge => charge.IsProcessed && charge.Category != ChargeCategory.Room)
                    .Sum(charge => charge.Amount);
            }
        }

        /// <summary>
        /// Gets the display value for total tax. Tax is not tracked by the current billing model.
        /// </summary>
        public string RevenueTaxDisplay
        {
            get
            {
                return "Not tracked";
            }
        }

        /// <summary>
        /// Gets total processed charges across all invoices.
        /// </summary>
        public decimal TotalInvoiceAmount
        {
            get
            {
                return _hotel.Invoices.Sum(invoice => invoice.TotalCharges);
            }
        }

        /// <summary>
        /// Gets total processed payments across all invoices.
        /// </summary>
        public decimal TotalPaidAmount
        {
            get
            {
                return _hotel.Invoices.Sum(invoice => invoice.TotalPayments);
            }
        }

        /// <summary>
        /// Gets the outstanding balance across all invoices.
        /// </summary>
        public decimal OutstandingBalance
        {
            get
            {
                return _hotel.Invoices.Sum(invoice => invoice.BalanceDue);
            }
        }
        #endregion
    }
}
