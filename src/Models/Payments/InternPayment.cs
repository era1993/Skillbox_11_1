namespace EntertpriseIS.Models
{
    /// <summary>
    /// Способ расчета зарплаты для интернов
    /// </summary>
    public class InternPayment : IPayment
    {
        /// <summary>
        /// Размер фиксированной оплаты
        /// </summary>
        public double FixedPayment { set; get; }

        public InternPayment(double fixedPayment)
        {
            FixedPayment = fixedPayment;
        }

        /// <summary>
        /// Реализация метода расчета зарплаты
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            return FixedPayment;
        }
    }
}
