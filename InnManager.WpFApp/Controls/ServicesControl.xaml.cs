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
    }
}
