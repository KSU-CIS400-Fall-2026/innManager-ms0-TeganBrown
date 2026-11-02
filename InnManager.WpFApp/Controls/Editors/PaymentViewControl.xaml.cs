using System;
using System.Windows;
using System.Windows.Controls;

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for PaymentViewControl.xaml
    /// </summary>
    public partial class PaymentViewControl : UserControl
    {
        public event EventHandler? BackAttempt;

        public PaymentViewControl()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            BackAttempt?.Invoke(this, EventArgs.Empty);
        }
    }
}
