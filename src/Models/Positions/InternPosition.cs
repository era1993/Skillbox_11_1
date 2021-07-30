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
        private double fixedPayment;
        /// <summary>
        /// Размер фиксированной зарплаты
        /// </summary>
        public double FixedPayment { set; get; }
        public InternPosition() : this(null, null, 0) { }
        public InternPosition(string description, string department, double fixedPayment)
            : base(description, department)
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

    public class InternPositionViewModel : PositionViewModel
    {
        public InternPositionViewModel(InternPosition position) : base(position) { }
        public double FixedPayment { set { (Value as InternPosition).FixedPayment = value; RaisePropertyChanged("FixedPayment"); } get { return (Value as InternPosition).FixedPayment; } }    
    }
}
