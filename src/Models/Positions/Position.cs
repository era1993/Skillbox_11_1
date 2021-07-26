using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string description;

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        private string department;

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Description { set { description = value; RaisePropertyChanged("Description"); } get { return description; } }

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        public string Department { set { department = value; RaisePropertyChanged("Department"); } get { return department; } }

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
}
