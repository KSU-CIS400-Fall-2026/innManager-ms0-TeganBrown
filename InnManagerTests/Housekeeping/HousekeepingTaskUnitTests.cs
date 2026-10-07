using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Housekeeping
{
    /// <summary>
    /// Runs tests for the HousekeepingTask class in InnManager
    /// </summary>
    public class HousekeepingTaskUnitTests
    {
        /// <summary>
        /// Ensures that default values are correct
        /// </summary>
        [Fact]
        public void HousekeepingTaskDefaultValuesTest()
        {
            HousekeepingTask task = new HousekeepingTask();
            Assert.Equal(task.RoomNumber, string.Empty);
            Assert.Equal(task.Description, string.Empty);
            Assert.Equal(task.ScheduledDate.Date, DateTime.Now.Date);
            Assert.False(task.IsCompleted);
            Assert.Equal(task.Status, "Not Completed");
        }
    }
}
