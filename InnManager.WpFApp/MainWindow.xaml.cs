using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InnManager.WpFApp.Controls;

namespace InnManager.WpFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Hotel _hotel = new Hotel("TestHotel", HotelType.Standard);

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _hotel;
            contentControl.Content = new DashboardControl();
        }

        /// <summary>
        /// Displays the Dashboard in the Main Window when the dashboard button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void DashboardClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new DashboardControl();
        }
        /// <summary>
        /// Displays the Rooms in the Main Window when the rooms button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void RoomsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new RoomsControl();

        }
        /// <summary>
        /// Displays the Reservations in the Main Window when the reservations button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void ReservationsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ReservationsControl();
        }
        /// <summary>
        /// Displays the Guests in the Main Window when the guests button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void GuestsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new GuestsControl();
        }
        /// <summary>
        /// Displays the Services in the Main Window when the services button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void ServicesClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ServicesControl();
        }
        /// <summary>
        /// Displays the Invoices in the Main Window when the invoices button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void InvoicesClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new InvoicesControl();
        }
        /// <summary>
        /// Displays the Payments in the Main Window when the payments button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void PaymentsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new PaymentsControl();
        }
        /// <summary>
        /// Displays the Employees in the Main Window when the employees button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void EmployeesClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new EmployeesControl();
        }
        /// <summary>
        /// Displays the Housekeeping in the Main Window when the housekeeping button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void HousekeepingClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new HousekeepingControl();
        }
        /// <summary>
        /// Displays the Reports in the Main Window when the reports button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void ReportsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ReportsControl();
        }
        /// <summary>
        /// Displays the Settings in the Main Window when the settings button is clicked
        /// </summary>
        /// <param name="sender">The object signaling the event</param>
        /// <param name="e">The event that occurs</param>
        public void SettingsClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new SettingsControl();
        }
    }
}