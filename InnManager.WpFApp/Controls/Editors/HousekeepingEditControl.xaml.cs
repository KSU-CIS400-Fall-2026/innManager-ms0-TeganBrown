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

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for HousekeepingEditControl.xaml
    /// </summary>
    public partial class HousekeepingEditControl : UserControl
    {
        public HousekeepingEditControl()
        {
            InitializeComponent();
            StatusComboBox.ItemsSource = new[]
            {
                new KeyValuePair<string, bool>("Completed", true),
                new KeyValuePair<string, bool>("Not Completed", false)
            };
        }

        public event EventHandler? CancelAttempt;
        public event EventHandler? SaveAttempt;

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not HousekeepingTask)
            {
                MessageBox.Show("Select a housekeeping task to edit.");
                return;
            }

            if (RoomComboBox.SelectedItem is not Room)
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            if (string.IsNullOrWhiteSpace(AssignedStaffComboBox.Text))
            {
                MessageBox.Show("Please select a staff member.");
                return;
            }

            if (StatusComboBox.SelectedValue is not bool)
            {
                MessageBox.Show("Please select a Status.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a Description.");
                return;
            }

            if (!ScheduledDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please enter a Scheduled Date.");
                return;
            }

            UpdateValues();
            SaveAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancelAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateValues()
        {
            RoomComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
            AssignedStaffComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            StatusComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            ScheduledDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty)?.UpdateSource();
        }
    }
}
