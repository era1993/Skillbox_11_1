using EntertpriseIS.Models;
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
    /// Логика взаимодействия для uiPositionSelector.xaml
    /// </summary>
    public partial class uiPositionSelector : UserControl
    {
        public uiPositionSelector()
        {
            InitializeComponent();
        }

        private void btnPosition_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Person person = btn.DataContext as Person;
            switch (btn.Name)
            {
                case "btnPositionManager": person.Position = new ManagerPosition("Управляющий", Enterprise.Current.Name); break;
                case "btnPositionIntern": person.Position = new InternPosition("Интерн", Enterprise.Current.Name, 500); break;
                case "btnPositionWorkman": person.Position = new WorkmanPosition("Рабочий", Enterprise.Current.Name, 5, 160); break;
            }

        }
    }
}
