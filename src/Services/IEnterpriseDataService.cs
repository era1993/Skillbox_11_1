using EntertpriseIS.Models;

namespace EntertpriseIS.Services
{
    /// <summary>
    /// Интерфейс сервиса-источника данных
    /// </summary>
    public interface IEnterpriseDataService
    {
        /// <summary>
        /// Функция принудительной загрузки данных
        /// </summary>
        /// <returns></returns>
        Enterprise ManualLoad();

        /// <summary>
        /// Метод принудительного сохранения объекта
        /// </summary>
        /// <param name="enterprise"></param>
        void ManualSave(Enterprise enterprise);
    }
}
