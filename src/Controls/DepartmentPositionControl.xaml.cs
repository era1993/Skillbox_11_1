using EntertpriseIS.Models;
using M=MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class DepartmentPositionControl : UserControl
    {
        public DepartmentPositionControl()
        {
            InitializeComponent();
            btnDepartmentList.ItemsSource = Enterprise.Current.Departments;
            btnDepartmentList.DataContext = Enterprise.Current.Departments;

        }


        private void SplitButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selected = (sender as M.SplitButton).SelectedValue as Department;
            Position position = this.DataContext as Position;
            position.Department = selected.Name;
        }
    }
}
