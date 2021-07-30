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

    public class WorkmanPositionViewModel : PositionViewModel
    {
        public WorkmanPositionViewModel(WorkmanPosition position) : base(position) { }

        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour
        {
            set { (Value as WorkmanPosition).PaymentPerHour = value; RaisePropertyChanged("PaymentPerHour"); }
            get { return (Value as WorkmanPosition).PaymentPerHour; }
        }

        /// <summary>
        /// Базовая ставка рабочего в часах
        /// </summary>
        public double DefaultHours
        {
            set { (Value as WorkmanPosition).DefaultHours = value; RaisePropertyChanged("DefaultHours"); }
            get { return (Value as WorkmanPosition).DefaultHours; }
        }
    }
}
