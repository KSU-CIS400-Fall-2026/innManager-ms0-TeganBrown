using System;
using System.Windows;
using System.Windows.Controls;

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for PaymentRefundControl.xaml
    /// </summary>
    public partial class PaymentRefundControl : UserControl
    {
        public event EventHandler? BackAttempt;

        public PaymentRefundControl()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            BackAttempt?.Invoke(this, EventArgs.Empty);
        }

        private void RefundPaymentClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to refund this payment?", "Confirm Refund", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ((Payment)DataContext).IsRefunded = true;
            }
        }
    }
}
