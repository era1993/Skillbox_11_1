using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Person
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Position Position { set; get; }

        public Person() : this(null) { }
        public Person(string name) => Name = name;

    }

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
                        case "Manager": Value.Position = new ManagerPosition("Управляющий", Enterprise.Current.Name); break;
                        case "Intern": Value.Position = new InternPosition("Интерн", Enterprise.Current.Name, 500); break;
                        case "Workman": Value.Position = new WorkmanPosition("Рабочий", Enterprise.Current.Name, 5, 160); break;
                    }
                    RaisePropertyChanged("Position");
                },
                _ => Value != null
                );
            if (Value.Position is InternPosition ip)
                Position = new InternPositionViewModel(ip);
            if (Value.Position is ManagerPosition mp)
                Position = new ManagerPositionViewModel(mp);
            if (Value.Position is WorkmanPosition wp)
                Position = new WorkmanPositionViewModel(wp);
            else
                Position = new PositionViewModel(Value.Position);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string property) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
    }

}
