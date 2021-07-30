using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private ICommand _positionSetCommand = null;
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        private Position position;

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Name { set; get; }

        [XmlIgnore]
        public ICommand PositionSetCommand => _positionSetCommand;

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Position Position { set { position = value; RaisePropertyChanged("Position"); } get { return position; } }

        public Person() : this(null) 
        { }
        public Person(string name)
        {
            Name = name;
            _positionSetCommand = new ActionCommand(
                parameter =>
                {
                    switch (parameter as string)
                    {
                        case "Manager": Position = new ManagerPosition("Управляющий", Enterprise.Current.Name); break;
                        case "Intern": Position = new InternPosition("Интерн", Enterprise.Current.Name, 500); break;
                        case "Workman": Position = new WorkmanPosition("Рабочий", Enterprise.Current.Name, 5, 160); break;
                    }
                },
                _ => true
                );
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string property) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
    }

    
}
