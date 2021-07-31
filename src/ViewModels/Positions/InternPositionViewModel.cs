using EntertpriseIS.Models;

namespace EntertpriseIS.ViewModels
{
    public class InternPositionViewModel : PositionViewModel
    {
        public InternPositionViewModel(InternPosition position) : base(position) { }
        /// <summary>
        /// Размер фиксированной зарплаты
        /// </summary>
        public double FixedPayment { set { (Value as InternPosition).FixedPayment = value; RaisePropertyChanged("FixedPayment"); } get { return (Value as InternPosition).FixedPayment; } }
    }
}
