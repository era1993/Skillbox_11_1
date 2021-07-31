namespace EntertpriseIS.Models
{
    /// <summary>
    /// Должность рабочего
    /// </summary>
    public class WorkmanPosition : Position
    {
        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour { set; get; }

        /// <summary>
        /// Базовая ставка рабочего в часах
        /// </summary>
        public double DefaultHours { set; get; }

        public WorkmanPosition() : this(null, null, 0, 0, null) { }
        public WorkmanPosition(string description, string department, double paymentPerHour, double defaultHours, Enterprise enterprise)
            : base(description, department, enterprise)
        {
            PaymentPerHour = paymentPerHour;
            DefaultHours = defaultHours;
        }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected override IPayment GetPayment()
        {
            return new WorkmanPayment(PaymentPerHour, DefaultHours);
        }
    }
}
