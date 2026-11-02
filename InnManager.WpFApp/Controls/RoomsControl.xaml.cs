using InnManager.WpFApp.Controls.Editors;
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
    /// Interaction logic for RoomsControl.xaml
    /// </summary>
    public partial class RoomsControl : UserControl
    {
        public RoomsControl()
        {
            InitializeComponent();
            RoomEditor.SaveAttempt += RoomEditorSaveAttempt;
            RoomEditor.CancelAttempt += RoomEditorCancelAttempt;
        }

        public void AddRoomClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            Window newRoomWindow = new AddRoomWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            newRoomWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (RoomsDataGrid.SelectedItem is Room selectedItem)
            {
                RoomEditor.DataContext = selectedItem;


                RoomPanel.Visibility = Visibility.Collapsed;
                RoomEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Room Selected.");
            }
        }

        private void RoomEditorSaveAttempt(object? sender, EventArgs e)
        {
            CloseRoomEditor();
        }

        private void RoomEditorCancelAttempt(object? sender, EventArgs e)
        {
            CloseRoomEditor();
        }

        private void CloseRoomEditor()
        {
            RoomEditor.Visibility = Visibility.Collapsed;
            RoomPanel.Visibility = Visibility.Visible;
            RoomEditor.DataContext = null;
        }

        private void DeleteRoomClick(object sender, RoutedEventArgs e)
        {
            if (RoomsDataGrid.SelectedItem is Room selectedItem)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete room {selectedItem.roomNumber}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ((Hotel)DataContext).Rooms.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("No Room Selected.");
            }
        }
    }
}
