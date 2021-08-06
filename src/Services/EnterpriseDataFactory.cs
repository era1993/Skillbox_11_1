namespace EntertpriseIS.Services
{
    /// <summary>
    /// Класс, определяющий логику по определению источника данных 
    /// </summary>
    public class EnterpriseDataFactory 
    {
        // Конструктор и его данные по умолчанию
        private const string xmlDataPath = "data.xml";

        /// <summary>
        /// Конструктоор по умоолчанию - создает XML-источник данных
        /// </summary>
        public EnterpriseDataFactory() : this(new EnterpriseDataServiceXml(xmlDataPath))
        { }

        /// <summary>
        /// Контструктор, позволяющий указать другой источник данных
        /// </summary>
        /// <param name="dataService"></param>
        public EnterpriseDataFactory(IEnterpriseDataService dataService)
        {
            DataService = dataService;
        }

        /// <summary>
        /// Сервис по обработке данных
        /// </summary>
        public IEnterpriseDataService DataService { get; }
    }
}
