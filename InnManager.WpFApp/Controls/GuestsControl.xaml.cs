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
    /// Interaction logic for GuestsControl.xaml
    /// </summary>
    public partial class GuestsControl : UserControl
    {
        public GuestsControl()
        {
            InitializeComponent();
            GuestEditor.SaveAttempt += GuestEditorAttempt;
            GuestEditor.CancelAttempt += GuestEditorAttempt;
        }

        private void AddGuestClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddGuestWindow addGuestWindow = new AddGuestWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addGuestWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (GuestsDataGrid.SelectedItem is Guest selectedItem)
            {
                GuestEditor.DataContext = selectedItem;
                GuestPanel.Visibility = Visibility.Collapsed;
                GuestEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Guest Selected.");
            }
        }

        private void GuestEditorAttempt(object? sender, EventArgs e)
        {
            GuestEditor.Visibility = Visibility.Collapsed;
            GuestPanel.Visibility = Visibility.Visible;
            GuestEditor.DataContext = null;
        }

        private void DeleteGuestClick(object sender, RoutedEventArgs e)
        {
            if (GuestsDataGrid.SelectedItem is Guest selectedItem)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete guest {selectedItem.FirstName} {selectedItem.LastName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && DataContext is Hotel hotel)
                {
                    hotel.Guests.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("No Guest Selected.");
            }
        }
    }
}
