using EntertpriseIS.Models;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace EntertpriseIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string dataPath = "data.xml";
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                if (File.Exists(dataPath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Enterprise));
                    using (FileStream fs = File.OpenRead(dataPath))
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                        Enterprise.Current = xs.Deserialize(sr) as Enterprise;
                }
                if (Enterprise.Current == null)
                {
                    Enterprise.Current = new Enterprise();
                }
                this.DataContext = Enterprise.Current;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Инициализация прошла с ошибкой: {ex.Message}");
            }
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Enterprise));
                using (FileStream fs = File.Create(dataPath))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    xs.Serialize(sw, Enterprise.Current);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сохранение прошло с ошибкой: {ex.Message}");
            }
        }
    }
}
