using System.ComponentModel;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        private Position position;

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Position Position { set { position = value; RaisePropertyChanged("Position"); } get { return position; } }

        public Person() : this(null) 
        { }
        public Person(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string property) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
    }

}
