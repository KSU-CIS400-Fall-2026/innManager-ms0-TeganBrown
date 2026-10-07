using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Hotels
{
    /// <summary>
    /// Runs tests for the Hotel class in InnManager
    /// </summary>
    public class HotelUnitTests
    {
        /// <summary>
        /// Ensures that default values are correct
        /// </summary>
        [Fact]
        public void HotelDefaultValuesTest()
        {
            Hotel hotel = new Hotel("Grandview Hotel", HotelType.Business);
            Assert.Empty(hotel.Rooms);
            Assert.Empty(hotel.Guests);
            Assert.Empty(hotel.Reservations);
            Assert.Empty(hotel.Services);
            Assert.Empty(hotel.Invoices);
            Assert.Empty(hotel.Payments);
            Assert.Empty(hotel.Employees);
            Assert.Empty(hotel.HousekeepingTasks);
            Assert.Equal(hotel.AvailableRoomCount, 0);
            Assert.Equal(hotel.OccupiedRoomCount, 0);
        }
        /// <summary>
        /// Makes sure that the number of available and occupied rooms is accurate
        /// </summary>
        /// <param name="status1">status of room 1</param>
        /// <param name="status2">status of room 2</param>
        /// <param name="status3">status of room 3</param>
        /// <param name="status4">status of room 4</param>
        /// <param name="status5">status of room 5</param>
        /// <param name="exAvail">The number of expected available rooms</param>
        /// <param name="exOcc">The number of expected occupied rooms</param>
        [Theory]
        [InlineData(RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, 5, 0)]
        [InlineData(RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, 0, 5)]
        [InlineData(RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Available, 3, 2)]
        [InlineData(RoomStatus.Reserved, RoomStatus.Maintenance, RoomStatus.Reserved, RoomStatus.Maintenance, RoomStatus.Reserved, 0, 0)]
        [InlineData(RoomStatus.Available, RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Maintenance, RoomStatus.Available, 2, 1)]
        [InlineData(RoomStatus.Occupied, RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Maintenance, RoomStatus.Available, 1, 2)]
        [InlineData(RoomStatus.Maintenance, RoomStatus.Available, RoomStatus.Maintenance, RoomStatus.Available, RoomStatus.Occupied, 2, 1)]
        [InlineData(RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Reserved, 1, 2)]
        public void CheckAvailibleRoomCountIsEqualToAvailableRooms(RoomStatus status1, RoomStatus status2, RoomStatus status3, RoomStatus status4, RoomStatus status5, int exAvail, int exOcc)
        {
            Hotel hotel = new Hotel("", HotelType.Business);
            Room room1 = new Room();
            room1.Status = status1;
            hotel.Rooms.Add(room1);
            Room room2 = new Room();
            room2.Status = status2;
            hotel.Rooms.Add(room2);
            Room room3 = new Room();
            room3.Status = status3;
            hotel.Rooms.Add(room3);
            Room room4 = new Room();
            room4.Status = status4;
            hotel.Rooms.Add(room4);
            Room room5 = new Room();
            room5.Status = status5;
            hotel.Rooms.Add(room5);
            Assert.Equal(exAvail, hotel.AvailableRoomCount);
            Assert.Equal(exOcc, hotel.OccupiedRoomCount);
        }
        
        


    }
}
