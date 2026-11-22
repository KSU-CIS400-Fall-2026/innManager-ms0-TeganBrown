using System;
using System.Collections.Generic;
using System.Text;
using InnManager.Hotels;
using InnManager.Reservations;
using InnManager.Rooms;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Enums;

namespace InnManager
{
    public static class HotelSampleData
    {

        private static readonly Hotel _hotel = BuildSampleHotel();


        /// <summary>
        /// Provides a hotel containing sample information
        /// </summary>
        public static Hotel SampleHotel => _hotel;
        /// <summary>
        /// Provides all sample rooms
        /// </summary>
        public static ObservableCollection<Room> Rooms => _hotel.Rooms;
        /// <summary>
        /// Provides all sample reservations
        /// </summary>
        public static ObservableCollection<Reservation> Reservations => _hotel.Reservations;
        /// <summary>
        /// Provides all sample Guests
        /// </summary>
        public static ObservableCollection<Guest> Guests => _hotel.Guests;

        /// <summary>
        /// Provides all sample housekeeping tasks
        /// </summary>
        public static ObservableCollection<HousekeepingTask> HousekeepingTasks => _hotel.HousekeepingTasks;

        /// <summary>
        /// Creates a hotel containing sample information
        /// </summary>
        /// <returns></returns>
        private static Hotel BuildSampleHotel()
        {

            var hotel = new Hotel("Sample Hotel", HotelType.Standard);



            hotel.Rooms.Add(new Room()
            {
                roomNumber = "101",
                roomType = RoomType.Standard,
                Status = RoomStatus.Available,
                NightlyRate = 100.00m
            });
            hotel.Rooms.Add(new Room()
            {
                roomNumber = "102",
                roomType = RoomType.Standard,
                Status = RoomStatus.Occupied,
                NightlyRate = 100.00m
            });
            hotel.Rooms.Add(new Room()
            {
                roomNumber = "201",
                roomType = RoomType.Family,
                Status = RoomStatus.Maintenance,
                NightlyRate = 150.00m
            });
            hotel.Rooms.Add(new Room()
            {
                roomNumber = "202",
                roomType = RoomType.Family,
                Status = RoomStatus.Available,
                NightlyRate = 150.00m
            });
            hotel.Rooms.Add(new Room()
            {
                roomNumber = "301",
                roomType = RoomType.Suite,
                Status = RoomStatus.Maintenance,
                NightlyRate = 300.00m
            });
            hotel.Rooms.Add(new Room()
            {
                roomNumber = "302",
                roomType = RoomType.Suite,
                Status = RoomStatus.Reserved,
                NightlyRate = 300.00m
            });

            hotel.Guests.Add(new Guest()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johnd@gmail.com",
                IDNumber = "123456789",
                PhoneNumber = "582-5477",
                GuestID = "GST-" + "Doe".Substring(0,2).ToUpper() + "-" + "123456789".Substring("123456789".Length - 3, 3),
            });
            hotel.Guests.Add(new Guest()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janed@gmail.com",
                IDNumber = "987654321",
                PhoneNumber = "555-1212",
                GuestID = "GST-" + "Doe".Substring(0, 2).ToUpper() + "-" + "987654321".Substring("987654321".Length - 3, 3),
            });
            hotel.Guests.Add(new Guest()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bobbysmith@yahoo.com",
                IDNumber = "456789123",
                PhoneNumber = "555-0101",
                GuestID = "GST-" + "Smith".Substring(0, 2).ToUpper() + "-" + "456789123".Substring("456789123".Length - 3, 3)
            });
            hotel.Guests.Add(new Guest()
            {
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "ajohnson@hotmail.com",
                IDNumber = "789123456",
                PhoneNumber = "555-9876",
                GuestID = "GST-" + "Johnson".Substring(0, 2).ToUpper() + "-" + "789123456".Substring("789123456".Length - 3, 3)
            });
            hotel.Guests.Add(new Guest()
            {
                FirstName = "Charlie",
                LastName = "Brown",
                Email = "cbrown@aol.com",
                IDNumber = "321654987",
                PhoneNumber = "555-5555",
                GuestID = "GST-" + "Brown".Substring(0, 2).ToUpper() + "-" + "321654987".Substring("321654987".Length - 3, 3)
            });

            hotel.Reservations.Add(new Reservation()
            {
                GuestName = hotel.Guests[0].ToString(),
                Room = hotel.Rooms[0],
                Status = "Pending",
                ReservationNumber = "RES-" + hotel.Guests[0].LastName.Substring(0, 2).ToUpper() + "-" + hotel.Guests[0].IDNumber.Substring(hotel.Guests[0].IDNumber.Length - 3, 3) + "-" + hotel.Rooms[0].roomNumber,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(3),
            });
            hotel.Reservations.Add(new Reservation()
            {
                GuestName = hotel.Guests[1].ToString(),
                Room = hotel.Rooms[1],
                Status = "Confirmed",
                ReservationNumber = "RES-" + hotel.Guests[1].LastName.Substring(0, 2).ToUpper() + "-" + hotel.Guests[1].IDNumber.Substring(hotel.Guests[1].IDNumber.Length - 3, 3) + "-" + hotel.Rooms[1].roomNumber,
                CheckInDate = DateTime.Today.AddDays(-1),
                CheckOutDate = DateTime.Today.AddDays(2),
            });
            hotel.Reservations.Add(new Reservation()
            {
                GuestName = hotel.Guests[2].ToString(),
                Room = hotel.Rooms[2],
                Status = "Checked Out",
                ReservationNumber = "RES-" + hotel.Guests[2].LastName.Substring(0, 2).ToUpper() + "-" + hotel.Guests[2].IDNumber.Substring(hotel.Guests[2].IDNumber.Length - 3, 3) + "-" + hotel.Rooms[2].roomNumber,
                CheckInDate = DateTime.Today.AddDays(-3),
                CheckOutDate = DateTime.Today.AddDays(-1)
            });
            hotel.Reservations.Add(new Reservation()
            {
                GuestName = hotel.Guests[3].ToString(),
                Room = hotel.Rooms[3],
                Status = "Overdue",
                ReservationNumber = "RES-" + hotel.Guests[3].LastName.Substring(0, 2).ToUpper() + "-" + hotel.Guests[3].IDNumber.Substring(hotel.Guests[3].IDNumber.Length - 3, 3) + "-" + hotel.Rooms[3].roomNumber,
                CheckInDate = DateTime.Today.AddDays(-2),
                CheckOutDate = DateTime.Today.AddDays(1)
            });
            hotel.Reservations.Add(new Reservation()
            {
                GuestName = hotel.Guests[4].ToString(),
                Room = hotel.Rooms[4],
                Status = "Pending",
                ReservationNumber = "RES-" + hotel.Guests[4].LastName.Substring(0, 2).ToUpper() + "-" + hotel.Guests[4].IDNumber.Substring(hotel.Guests[4].IDNumber.Length - 3, 3) + "-" + hotel.Rooms[4].roomNumber,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(3)
            });

            hotel.HousekeepingTasks.Add(new HousekeepingTask()
            {
                Description = "Clean room 101",
                RoomNumber = "101",
                AssignedStaff = "Devin, Robert",
                ScheduledDate = DateTime.Today.AddDays(5),
                IsCompleted = false,
            });
            hotel.HousekeepingTasks.Add(new HousekeepingTask()
            {
                Description = "Deliver Breakfast to Suite 301",
                RoomNumber = "301",
                AssignedStaff = "Eggbert, Ronald",
                ScheduledDate = DateTime.Today.AddDays(1),
                IsCompleted = true,
            });
            hotel.HousekeepingTasks.Add(new HousekeepingTask()
            {
                Description = "Make beds in Room 202",
                RoomNumber = "202",
                AssignedStaff = "Erving, Ester",
                ScheduledDate = DateTime.Today.AddDays(2),
                IsCompleted = false,
            });
            hotel.HousekeepingTasks.Add(new HousekeepingTask()
            {
                Description = "Clean bathroom in Room 201",
                RoomNumber = "201",
                AssignedStaff = "Regan, Ed",
                ScheduledDate = DateTime.Today.AddDays(-4),
                IsCompleted = true,
            });

            return hotel;
        }
    }
}



