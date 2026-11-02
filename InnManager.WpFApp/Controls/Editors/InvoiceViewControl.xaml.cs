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

namespace InnManager.WpFApp.Controls.Editors
{
    /// <summary>
    /// Interaction logic for InvoiceEditControl.xaml
    /// </summary>
    public partial class InvoiceEditControl : UserControl
    {
        public event EventHandler? BackAttempt;

        public InvoiceEditControl()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            BackAttempt?.Invoke(this, EventArgs.Empty);
        }
    }
}
