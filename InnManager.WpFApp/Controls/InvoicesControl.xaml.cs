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
    /// Interaction logic for InvoicesControl.xaml
    /// </summary>
    public partial class InvoicesControl : UserControl
    {
        public InvoicesControl()
        {
            InitializeComponent();
            InvoiceViewer.BackAttempt += InvoiceViewerBackAttempt;
        }

        private void AddInvoiceClick(object sender, RoutedEventArgs e)
        {
            Hotel hotel = DataContext as Hotel;
            AddInvoiceWindow addInvoiceWindow = new AddInvoiceWindow(hotel)
            {
                Owner = Window.GetWindow(this)
            };
            addInvoiceWindow.ShowDialog();
        }

        private void ViewInvoiceClick(object sender, RoutedEventArgs e)
        {
            if (InvoicesDataGrid.SelectedItem is Invoice selectedItem)
            {
                InvoiceViewer.DataContext = selectedItem;


                InvoicesPanel.Visibility = Visibility.Collapsed;
                InvoiceViewer.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Invoice Selected.");
            }
        }

        private void InvoiceViewerBackAttempt(object? sender, EventArgs e)
        {
            InvoiceViewer.Visibility = Visibility.Collapsed;
            InvoicesPanel.Visibility = Visibility.Visible;
            InvoiceViewer.DataContext = null;
        }
    }
}
