using EntertpriseIS.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
    public class PositionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Объект представления
        /// </summary>
        public Position Value { get; private set; }
        private ICommand _departmentSetCommand = null;
        /// <summary>
        /// Команда установки департамента объекту предсставления
        /// </summary>
        public ICommand DepartmentSetCommand => _departmentSetCommand;

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Description { set { Value.Description = value; RaisePropertyChanged("Description"); } get => Value.Description; }

        /// <summary>
        /// Наименование департамента, которому принадлежит должность
        /// </summary>
        public string Department { set { Value.Department = value; RaisePropertyChanged("Department"); } get => Value.Department; }

        /// <summary>
        /// Модель представления метода расчета зарплаты
        /// </summary>
        public PaymentViewModel Payment { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public virtual void RefreshPayment()
        {
            Value.RefreshPayment();
            Payment = new PaymentViewModel(Value.Payment);
            RaisePropertyChanged("Payment");
        }

        public PositionViewModel(Position position)
        {
            Value = position;
            _departmentSetCommand = new ActionCommand(
                department => Department = (department as DepartmentViewModel).Name,
                _ => Value != null);
            RefreshPayment();
        }
    }
}
