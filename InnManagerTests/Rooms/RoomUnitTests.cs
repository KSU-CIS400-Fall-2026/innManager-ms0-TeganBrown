using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Rooms
{
    /// <summary>
    /// Runs tests for the Room Class in InnManager
    /// </summary>
    public class RoomUnitTests
    {
        /// <summary>
        /// Ensures all default values are correct
        /// </summary>
        [Fact]
        public void RoomDefaultValuesTest()
        {
            Room room = new Room();
            Assert.Equal(room.Floor, 0);
            Assert.Equal(room.Capacity, 1);
            Assert.False(room.HasBalcony);
            Assert.True(room.IsClean);
            Assert.Equal(room.roomType, RoomType.Standard);
            Assert.Equal(room.Status, RoomStatus.Available);
        }
    }
}
