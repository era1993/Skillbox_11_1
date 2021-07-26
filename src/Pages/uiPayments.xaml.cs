using EntertpriseIS.Models;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntertpriseIS
{
    /// <summary>
    /// Логика взаимодействия для uiPayments.xaml
    /// </summary>
    public partial class uiPayments : MetroTabItem
    {
        public uiPayments()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Enterprise.Current.RefreshPayments();
            var context = this.DataContext;
            this.DataContext = null;
            this.DataContext = context;
        }
    }

    public class PersonPaymentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Person person)
            {
                return person.Position.Payment.Calculate();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
