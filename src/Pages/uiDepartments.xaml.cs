using EntertpriseIS.Models;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace EntertpriseIS
{
    /// <summary>
    /// Логика взаимодействия для uiDepartments.xaml
    /// </summary>
    public partial class uiDepartments : MetroTabItem
    {
        public uiDepartments()
        {
            InitializeComponent();
        }

        private void AddNewDepartment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Enterprise enterprise = (sender as FrameworkElement).DataContext as Enterprise;
            if (enterprise == null)
                return;

            enterprise.Departments.Add(new Department($"Департамент №{enterprise.Departments.Count + 1}", enterprise.Name));
        }


        private void SplitButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grid grid = (sender as FrameworkElement).GetVisualAncestor<Grid>() as Grid;
            Department selected = (sender as FrameworkElement).DataContext as Department;
            Department department = grid.DataContext as Department;
            if (department != null && selected != null)
                department.HiglLevelDepartment = selected.Name;
        }
    }
}
