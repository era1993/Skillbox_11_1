namespace EntertpriseIS.Models
{
    /// <summary>
    /// Должность интерна
    /// </summary>
    public class InternPosition : Position
    {
        /// <summary>
        /// Размер фиксированной зарплаты
        /// </summary>
        public double FixedPayment { set; get; }
        public InternPosition() : this(null, null, 0, null) { }
        public InternPosition(string description, string department, double fixedPayment, Enterprise enterprise)
            : base(description, department, enterprise)
        {
            FixedPayment = fixedPayment;
        }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected override IPayment GetPayment()
        {
            return new InternPayment(FixedPayment);
        }
    }
}
