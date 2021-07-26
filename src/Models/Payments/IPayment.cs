namespace EntertpriseIS.Models
{
    /// <summary>
    /// Интерфейс способа расчета платежа
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Реализация метода расчета зарплаты
        /// </summary>
        /// <returns></returns>
        double Calculate();
    }
}
