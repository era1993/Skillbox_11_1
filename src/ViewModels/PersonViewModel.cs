using EntertpriseIS.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public Person Value { get; private set; }
        private ICommand _positionSetCommand = null;
        public ICommand PositionSetCommand => _positionSetCommand;

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Name { set { Value.Name = value; RaisePropertyChanged("Name"); } get => Value.Name; }
        public PositionViewModel Position { set; get; }

        public PersonViewModel(Person person)
        {
            Value = person;
            _positionSetCommand = new ActionCommand(
                parameter =>
                {
                    switch (parameter as string)
                    {
                        case "Manager": Value.Position = new ManagerPosition("Управляющий", person.Enterprise.Name, Value.Enterprise); break;
                        case "Intern": Value.Position = new InternPosition("Интерн", person.Enterprise.Name, 500, Value.Enterprise); break;
                        case "Workman": Value.Position = new WorkmanPosition("Рабочий", person.Enterprise.Name, 5, 160, Value.Enterprise); break;
                    }
                    InitPosition();
                },
                _ => Value != null
                );
            InitPosition();
        }

        private void InitPosition()
        {
            if (Value.Position == null)
                Position = null;
            else if (Value.Position is InternPosition ip)
                Position = new InternPositionViewModel(ip);
            else if (Value.Position is ManagerPosition mp)
                Position = new ManagerPositionViewModel(mp);
            else if (Value.Position is WorkmanPosition wp)
                Position = new WorkmanPositionViewModel(wp);
            else
                Position = new PositionViewModel(Value.Position);
            RaisePropertyChanged("Position");
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string property) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
    }
}
