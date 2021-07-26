namespace EntertpriseIS.Models
{
    /// <summary>
    /// Метод расчета зарплаты рабочего
    /// </summary>
    public class WorkmanPayment : IPayment
    {
        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour { get; }

        /// <summary>
        /// Объем оплаты в часах
        /// </summary>
        public double Hours { get; }

        public WorkmanPayment(double paymentPerHour, double hours)
        {
            PaymentPerHour = paymentPerHour;
            Hours = hours;
        }

        /// <summary>
        /// Реализация метода расчета зарплаты
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            return PaymentPerHour * Hours;
        }
    }
}
