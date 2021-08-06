using System;
using System.Windows;

namespace EntertpriseIS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App():base()
        {
            AppDomain.CurrentDomain.UnhandledException += (ls, le) => MessageBox.Show(le.ExceptionObject.ToString());
        }
    }
}
