using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InnManager.Rooms;
using InnManager.Reservations;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager;


namespace InnManagerWebsite.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Gets the rooms in the sample hotel.
        /// </summary>
        public IEnumerable<Room> Rooms => HotelSampleData.Rooms;
        /// <summary>
        /// Gets the reservations in the sample hotel.
        /// </summary>
        public IEnumerable<Reservation> Reservations => HotelSampleData.Reservations;
        /// <summary>
        /// Gets the guests in the sample hotel.
        /// </summary>
        public IEnumerable<Guest> Guests => HotelSampleData.Guests;
        /// <summary>
        /// Gets the housekeeping tasks in the sample hotel.
        /// </summary>
        public IEnumerable<HousekeepingTask> HousekeepingTasks => HotelSampleData.HousekeepingTasks;


        public void OnGet()
        {
            
        }
    }
}
