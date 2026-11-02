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
    /// Interaction logic for ServicesControl.xaml
    /// </summary>
    public partial class ServicesControl : UserControl
    {
        public ServicesControl()
        {
            InitializeComponent();
            ServiceEditor.SaveAttempt += ServiceEditorAttempt;
            ServiceEditor.CancelAttempt += ServiceEditorAttempt;
        }

        private void AddServiceClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddServiceWindow addServiceWindow = new AddServiceWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addServiceWindow.ShowDialog();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Service selectedItem)
            {
                ServiceEditor.DataContext = selectedItem;
                ServicePanel.Visibility = Visibility.Collapsed;
                ServiceEditor.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Service Selected.");
            }
        }

        private void ServiceEditorAttempt(object? sender, EventArgs e)
        {
            ServiceEditor.Visibility = Visibility.Collapsed;
            ServicePanel.Visibility = Visibility.Visible;
            ServiceEditor.DataContext = null;
        }

        private void DeleteServiceClick(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Service selectedItem)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete service {selectedItem.ServiceName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && DataContext is Hotel hotel)
                {
                    hotel.Services.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("No Service Selected.");
            }
        }
    }
}
