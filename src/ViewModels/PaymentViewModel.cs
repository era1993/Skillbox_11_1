using EntertpriseIS.Models;

namespace EntertpriseIS.ViewModels
{
    public class PaymentViewModel
    {
        /// <summary>
        /// Объект представления
        /// </summary>
        private IPayment _payment;
        /// <summary>
        /// Размер заработно платы объекта представления
        /// </summary>
        public double Payment => _payment.Calculate();

        public PaymentViewModel(IPayment payment) => _payment = payment;

        public override string ToString() => Payment.ToString();
    }
}
