using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Базовый класс должности сотрудника
    /// </summary>
    [XmlInclude(typeof(ManagerPosition))]
    [XmlInclude(typeof(InternPosition))]
    [XmlInclude(typeof(WorkmanPosition))]
    public abstract class Position 
    {
        /// <summary>
        /// Сохраненный вариант расчета заработной платы
        /// </summary>
        private IPayment payment;

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        public string Department { set; get; }

        /// <summary>
        /// Вариант расчета заработной платы
        /// </summary>
        public IPayment Payment
        {
            get
            {
                if (payment == null)
                    payment = GetPayment();
                return payment;
            }
        }

        /// <summary>
        /// Ссылка на организацию, которой принадлежит должность
        /// </summary>
        [XmlIgnore] public Enterprise Enterprise { set; get; }


        public Position() : this(null, null, null) { }
        public Position(string description, string department, Enterprise enterprise)
        {
            Description = description;
            Department = department;
            Enterprise = enterprise;
        }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected abstract IPayment GetPayment();
        public virtual void RefreshPayment()
        {
            payment = GetPayment();
        }
    }    
}
