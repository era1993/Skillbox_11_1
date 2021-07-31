using EntertpriseIS.Models;
using EntertpriseIS.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Text;
using System.Windows;
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
                Enterprise current = null;
                if (File.Exists(dataPath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Enterprise));
                    using (FileStream fs = File.OpenRead(dataPath))
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                        current = xs.Deserialize(sr) as Enterprise;
                }
                if (current == null)
                {
                    current = new Enterprise();
                }
                foreach (var i in current.Persons)
                {
                    i.Enterprise = current;
                    i.Position.Enterprise = current;
                }
                foreach (var i in current.Departments)
                    i.Enterprise = current;
                this.DataContext = new EnterpriseViewModel(current);
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
                    xs.Serialize(sw, (this.DataContext as EnterpriseViewModel).Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сохранение прошло с ошибкой: {ex.Message}");
            }
        }
    }
}
