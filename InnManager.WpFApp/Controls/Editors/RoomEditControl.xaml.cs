using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for RoomEditControl.xaml
    /// </summary>
    public partial class RoomEditControl : UserControl
    {

        public event EventHandler? CancelAttempt;

        public event EventHandler? SaveAttempt;


        public RoomEditControl()
        {
            InitializeComponent();
            RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType));
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(RoomStatus));
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not Room)
            {
                MessageBox.Show("Select a room to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(RoomNumberTextBox.Text))
            {
                MessageBox.Show("Please enter a room number.");
                return;
            }

            if (RoomTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            if (!decimal.TryParse(RateTextBox.Text, out decimal nightlyRate) || nightlyRate < 1)
            {
                MessageBox.Show("Please enter a valid nightly rate.");
                return;
            }

            if (!int.TryParse(FloorTextBox.Text, out int floor) || floor < 1)
            {
                MessageBox.Show("Please enter a valid floor number.");
                return;
            }

            if (!int.TryParse(CapacityTextBox.Text, out int capacity) || capacity < 1)
            {
                MessageBox.Show("Please enter a valid capacity.");
                return;
            }

            if (!HasBalconyCheckBox.IsChecked.HasValue || !IsCleanCheckBox.IsChecked.HasValue)
            {
                MessageBox.Show("Please specify the room's cleaning and balcony status.");
                return;
            }

            if (StatusComboBox.SelectedItem is not RoomStatus)
            {
                MessageBox.Show("Please select a room status.");
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
            RoomNumberTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            FloorTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            RoomTypeComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            StatusComboBox.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateSource();
            RateTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            CapacityTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            IsCleanCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();
            HasBalconyCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();

            ((Room)DataContext).isAvailable = (RoomStatus)StatusComboBox.SelectedItem == RoomStatus.Available;
        }
    }
}
