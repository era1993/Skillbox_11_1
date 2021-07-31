namespace EntertpriseIS.Models
{
    /// <summary>
    /// Должность руководителя
    /// </summary>
    public class ManagerPosition : Position
    {
        public ManagerPosition() : this(null, null, null) { }
        public ManagerPosition(string description, string department, Enterprise enterprise)
            : base(description, department, enterprise)
        { }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected override IPayment GetPayment()
        {
            return this.Enterprise == null ? null : new ManagerPayment(Enterprise.DepartmentByName(Department));
        }
    }
}
