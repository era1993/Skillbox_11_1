using EntertpriseIS.Models;

namespace EntertpriseIS.ViewModels
{
    public class WorkmanPositionViewModel : PositionViewModel
    {
        public WorkmanPositionViewModel(WorkmanPosition position) : base(position) { }

        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour
        {
            set { (Value as WorkmanPosition).PaymentPerHour = value; RaisePropertyChanged("PaymentPerHour"); }
            get { return (Value as WorkmanPosition).PaymentPerHour; }
        }

        /// <summary>
        /// Базовая ставка рабочего в часах
        /// </summary>
        public double DefaultHours
        {
            set { (Value as WorkmanPosition).DefaultHours = value; RaisePropertyChanged("DefaultHours"); }
            get { return (Value as WorkmanPosition).DefaultHours; }
        }
    }
}
