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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InnManager.Housekeeping;

namespace InnManager.WpFApp.Controls
{
    /// <summary>
    /// Interaction logic for HousekeepingControl.xaml
    /// </summary>
    public partial class HousekeepingControl : UserControl
    {
        public HousekeepingControl()
        {
            InitializeComponent();
            HousekeepingEditor.SaveAttempt += HousekeepingEditorAttempt;
            HousekeepingEditor.CancelAttempt += HousekeepingEditorAttempt;
        }

        private void AddHousekeepingTaskClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddHousekeepingTaskWindow addHousekeepingTaskWindow = new AddHousekeepingTaskWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addHousekeepingTaskWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Hotel hotel && HousekeepingTasksDataGrid.SelectedItem is HousekeepingTask selectedItem)
            {
                HousekeepingEditor.RoomComboBox.ItemsSource = hotel.Rooms;
                HousekeepingEditor.AssignedStaffComboBox.ItemsSource = hotel.Employees
                    .Select(employee => $"{employee.FirstName} {employee.LastName}")
                    .ToList();
                HousekeepingEditor.DataContext = selectedItem;
                HousekeepingPanel.Visibility = Visibility.Collapsed;
                HousekeepingEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Housekeeping Task Selected.");
            }
        }

        private void HousekeepingEditorAttempt(object? sender, EventArgs e)
        {
            HousekeepingEditor.Visibility = Visibility.Collapsed;
            HousekeepingPanel.Visibility = Visibility.Visible;
            HousekeepingEditor.DataContext = null;
        }

        private void DeleteHousekeepingTaskClick(object sender, RoutedEventArgs e)
        {
            if (HousekeepingTasksDataGrid.SelectedItem is HousekeepingTask selectedItem)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete the housekeeping task for room {selectedItem.RoomNumber}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && DataContext is Hotel hotel)
                {
                    hotel.HousekeepingTasks.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("No Housekeeping Task Selected.");
            }
        }
    }
}
