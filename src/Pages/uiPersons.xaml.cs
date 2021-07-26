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
    /// Логика взаимодействия для uiPersons.xaml
    /// </summary>
    public partial class uiPersons : MetroTabItem
    {
        public uiPersons()
        {
            InitializeComponent();
        }

        private void AddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            Enterprise enterprise = (sender as FrameworkElement).DataContext as Enterprise;
            if (enterprise == null)
                return;

            enterprise.Persons.Add(new Person($"Сотрудник №{enterprise.Persons.Count + 1}"));
        }
    }

    public class TypenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : value.GetType().Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
