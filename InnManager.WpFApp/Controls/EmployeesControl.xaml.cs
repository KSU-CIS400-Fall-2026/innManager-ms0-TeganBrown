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

namespace InnManager.WpFApp.Controls
{
    /// <summary>
    /// Interaction logic for EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl
    {
        public EmployeesControl()
        {
            InitializeComponent();
            EmployeeEditor.SaveAttempt += EmployeeEditorAttempt;
            EmployeeEditor.CancelAttempt += EmployeeEditorAttempt;
        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addEmployeeWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee selectedItem)
            {
                EmployeeEditor.DataContext = selectedItem;
                EmployeePanel.Visibility = Visibility.Collapsed;
                EmployeeEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Employee Selected.");
            }
        }

        private void EmployeeEditorAttempt(object? sender, EventArgs e)
        {
            EmployeeEditor.Visibility = Visibility.Collapsed;
            EmployeePanel.Visibility = Visibility.Visible;
            EmployeeEditor.DataContext = null;
        }

        private void DeactivateButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee selectedItem)
            {
                if (!selectedItem.IsActive)
                {
                    MessageBox.Show("This employee is already inactive.");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Are you sure you want to deactivate this employee?", "Confirm Deactivation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem.IsActive = false;
                }
            }
            else
            {
                MessageBox.Show("No Employee Selected.");
            }
        }
    }
}
