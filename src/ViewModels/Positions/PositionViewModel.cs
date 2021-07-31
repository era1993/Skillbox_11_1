using EntertpriseIS.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
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

    public class PaymentViewModel
    {
        private IPayment _payment;

        public double Payment => _payment.Calculate();

        public PaymentViewModel(IPayment payment) => _payment = payment;

        public override string ToString() => Payment.ToString();
    }
}
