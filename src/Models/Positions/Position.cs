using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Базовый класс должности сотрудника
    /// </summary>
    [XmlInclude(typeof(ManagerPosition))]
    [XmlInclude(typeof(InternPosition))]
    [XmlInclude(typeof(WorkmanPosition))]
    public abstract class Position : INotifyPropertyChanged
    {
        /// <summary>
        /// Наименование должности
        /// </summary>
        private string _description;

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        private string _department;


        private ICommand _departmentSetCommand = null;

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Description { set { _description = value; RaisePropertyChanged("Description"); } get { return _description; } }

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        public string Department { set { _department = value; RaisePropertyChanged("Department"); } get { return _department; } }

        /// <summary>
        /// Сохраненный вариант расчета заработной платы
        /// </summary>
        private IPayment payment;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

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

        [XmlIgnore]
        public ICommand DepartmentSetCommand => _departmentSetCommand;

        public Position() : this(null, null) { }
        public Position(string description, string department)
        {
            Description = description;
            Department = department;
            _departmentSetCommand = new ActionCommand(
                department => Department = (department as Department).Name,
                _ => true);
        }

        /// <summary>
        /// Реализация метода расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected abstract IPayment GetPayment();
        public virtual void RefreshPayment()
        {
            payment = GetPayment();
            RaisePropertyChanged("Payment");
        }
    }

    
}
