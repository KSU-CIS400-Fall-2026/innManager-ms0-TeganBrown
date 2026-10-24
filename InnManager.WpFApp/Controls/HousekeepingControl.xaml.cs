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
    /// Interaction logic for HousekeepingControl.xaml
    /// </summary>
    public partial class HousekeepingControl : UserControl
    {
        public HousekeepingControl()
        {
            InitializeComponent();
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
    }
}
