using EntertpriseIS.Services;
using EntertpriseIS.ViewModels;
using MahApps.Metro.Controls;

namespace EntertpriseIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new EnterpriseDataFactoryViewModel(new EnterpriseDataFactory());
        }
    }
}
