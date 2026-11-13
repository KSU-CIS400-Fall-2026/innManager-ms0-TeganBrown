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
    /// Interaction logic for PaymentReciptControl.xaml
    /// </summary>
    public partial class PaymentReciptControl : UserControl
    {
        public event EventHandler? BackAttempt;

        public PaymentReciptControl()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            BackAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
