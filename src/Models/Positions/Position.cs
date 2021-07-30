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


        public Position() : this(null, null) { }
        public Position(string description, string department)
        {
            Description = description;
            Department = department;
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

    public class PositionViewModel : INotifyPropertyChanged
    {
        public Position Value { get; private set; }
        private ICommand _departmentSetCommand = null;

        public ICommand DepartmentSetCommand => _departmentSetCommand;

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Description { set { Value.Description = value; RaisePropertyChanged("Description"); } get => Value.Description; }

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        public string Department { set { Value.Department = value; RaisePropertyChanged("Department"); } get => Value.Department; }

        public IPayment Payment { get => Value.Payment; }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public virtual void RefreshPayment()
        {
            Value.RefreshPayment();
            RaisePropertyChanged("Payment");
        }

        public PositionViewModel(Position position)
        {
            Value = position;
            _departmentSetCommand = new ActionCommand(
                department => Department = (department as Department).Name,
                _ => Value != null);
        }
    }
}
