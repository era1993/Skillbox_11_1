using EntertpriseIS.Models;
using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Windows.Data;

namespace EntertpriseIS
{
    /// <summary>
    /// Логика взаимодействия для uiPayments.xaml
    /// </summary>
    public partial class uiPayments : MetroTabItem
    {
        public uiPayments() => InitializeComponent();
    }

    public class PersonPaymentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value is IPayment payment) ? payment.Calculate() : null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
