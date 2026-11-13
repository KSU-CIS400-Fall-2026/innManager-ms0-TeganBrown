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

namespace InnManager.WpFApp.Settings
{
    /// <summary>
    /// Interaction logic for HotelInfo.xaml
    /// </summary>
    public partial class HotelInfo : UserControl
    {
        public HotelInfo()
        {
            InitializeComponent();
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(HotelType));
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
