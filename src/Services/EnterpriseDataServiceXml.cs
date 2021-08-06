using EntertpriseIS.Models;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EntertpriseIS.Services
{
    /// <summary>
    /// Реализация сервиса - источник данных типа XML файл
    /// </summary>
    public class EnterpriseDataServiceXml : IEnterpriseDataService
    {
        private string _dataPath;

        public EnterpriseDataServiceXml(string filePath)
        {
            _dataPath = filePath;
        }

        /// <summary>
        /// Загрузка объекта
        /// </summary>
        /// <returns></returns>
        public Enterprise ManualLoad()
        {
            Enterprise current = null;
            try
            {
                if (File.Exists(_dataPath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Enterprise));
                    using (FileStream fs = File.OpenRead(_dataPath))
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
            }
            catch (Exception ex)
            {
                throw new Exception($"Инициализация прошла с ошибкой: {ex.Message}", ex);
            }
            return current;
        }

        /// <summary>
        /// Сохранение объекта
        /// </summary>
        /// <param name="enterprise"></param>
        public void ManualSave(Enterprise enterprise)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Enterprise));
                using (FileStream fs = File.Create(_dataPath))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    xs.Serialize(sw, enterprise);
            }
            catch (Exception ex)
            {
                throw new Exception($"Сохранение прошло с ошибкой: {ex.Message}", ex);
            }
        }
    }


    
}
