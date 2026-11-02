using InnManager.Housekeeping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InnManager.WpFApp.AddWindows
{
    /// <summary>
    /// Interaction logic for AddHousekeepingTaskWindow.xaml
    /// </summary>
    public partial class AddHousekeepingTaskWindow : Window
    {
        private readonly Hotel _hotel;
        public AddHousekeepingTaskWindow(Hotel hotel)
        {
            InitializeComponent();
            _hotel = hotel;
            RoomComboBox.ItemsSource = _hotel.Rooms;
            AssignedStaffComboBox.ItemsSource = _hotel.Employees;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(HousekeepingTaskStatus));
        }

        private void AddTaskButtonClick(object sender, RoutedEventArgs e)
        {
            HousekeepingTask task = new HousekeepingTask();

            if (RoomComboBox.SelectedItem != null)
            {
                task.RoomNumber = ((Room)RoomComboBox.SelectedItem).roomNumber;
            }
            else
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            if (AssignedStaffComboBox.SelectedItem != null)
            {
                task.AssignedStaff = ((Employee)AssignedStaffComboBox.SelectedItem).FirstName + " " + ((Employee)AssignedStaffComboBox.SelectedItem).LastName;
            }
            else
            {
                MessageBox.Show("Please select a staff member.");
                return;
            }

            if (StatusComboBox.SelectedItem != null)
            {
                task.IsCompleted = (HousekeepingTaskStatus)StatusComboBox.SelectedItem == HousekeepingTaskStatus.Completed;
            }
            else
            {
                MessageBox.Show("Please select a Status.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a Description.");
                return;
            }
            else
            {
                task.Description = DescriptionTextBox.Text;
            }

            if (ScheduledDatePicker.SelectedDate.HasValue)
            {
                task.ScheduledDate = ScheduledDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please enter an Scheduled Date");
                return;
            }

            _hotel.HousekeepingTasks.Add(task);

            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
