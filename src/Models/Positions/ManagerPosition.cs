namespace EntertpriseIS.Models
{
    /// <summary>
    /// Должность руководителя
    /// </summary>
    public class ManagerPosition : Position
    {
        public ManagerPosition() : this(null, null) { }
        public ManagerPosition(string description, string department)
            : base(description, department)
        { }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected override IPayment GetPayment()
        {
            return new ManagerPayment(Department);
        }
    }

    public class ManagerPositionViewModel : PositionViewModel
    {
        public ManagerPositionViewModel(ManagerPosition position) : base(position) { }
    }
}
