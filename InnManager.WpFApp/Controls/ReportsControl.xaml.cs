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
using InnManager.WpFApp.ViewModels;

namespace InnManager.WpFApp.Controls
{
    /// <summary>
    /// Interaction logic for ReportsControl.xaml
    /// </summary>
    public partial class ReportsControl : UserControl
    {
        private HotelReportViewModel? _reportViewModel;

        public ReportsControl()
        {
            InitializeComponent();
            DataContextChanged += ReportsControlDataContextChanged;
        }

        private void ReportsControlDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _reportViewModel = e.NewValue is Hotel hotel
                ? new HotelReportViewModel(hotel)
                : null;
        }

        private void ShowReport(UserControl report)
        {
            if (_reportViewModel == null)
            {
                if (DataContext is not Hotel hotel)
                {
                    throw new InvalidOperationException("ReportsControl requires a Hotel data context.");
                }

                _reportViewModel = new HotelReportViewModel(hotel);
            }

            report.DataContext = _reportViewModel;
            ReportContentControl.Content = report;
        }

        private void OccupancyReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new OccupancyReport());
        }

        private void RevenueReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new RevenueReport());
        }

        private void GuestReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new GuestReport());
        }

        private void HousekeepingReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new HousekeepingReport());
        }

        private void ReservationReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new ReservationReport());
        }

        private void EmployeeReportClick(object sender, RoutedEventArgs e)
        {
            ShowReport(new EmployeeReport());
        }
    }
}
