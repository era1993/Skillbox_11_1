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
        private double paymentPerHour;

        /// <summary>
        /// Базовая ставка рабочего в часах
        /// </summary>
        private double defaultHours;

        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour 
        {
            set { paymentPerHour = value; RaisePropertyChanged("PaymentPerHour"); }
            get { return paymentPerHour; } 
        }

        /// <summary>
        /// Базовая ставка рабочего в часах
        /// </summary>
        public double DefaultHours
        {
            set { defaultHours = value; RaisePropertyChanged("DefaultHours"); }
            get { return defaultHours; }
        }

        public WorkmanPosition() : this(null, null, 0, 0) { }
        public WorkmanPosition(string description, string department, double paymentPerHour, double defaultHours)
            : base(description, department)
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
