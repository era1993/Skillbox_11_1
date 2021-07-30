using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EntertpriseIS
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class DepartmentPositionControl : UserControl, INotifyPropertyChanged
    {
        public DepartmentPositionControl()
        {
            InitializeComponent();
            mainCtrl.DataContext = this;
        }

        public static readonly DependencyProperty DepartmentProperty =
            DependencyProperty.Register(
                "Department", typeof(object),
                typeof(DepartmentPositionControl)
                );

        public static readonly DependencyProperty DepartmentSetCommandProperty =
            DependencyProperty.Register(
                "DepartmentSetCommand", typeof(ICommand),
                typeof(DepartmentPositionControl)
                );

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property) => PropertyChanged(this, new PropertyChangedEventArgs(property));

        public object Department
        {
            get { return GetValue(DepartmentProperty); }
            set { SetValue(DepartmentProperty, value); RaisePropertyChanged("Department"); }
        }

        public ICommand DepartmentSetCommand
        {
            get { return (ICommand)GetValue(DepartmentSetCommandProperty); }
            set { SetValue(DepartmentSetCommandProperty, value); RaisePropertyChanged("DepartmentSetCommand"); }
        }
    }
}
