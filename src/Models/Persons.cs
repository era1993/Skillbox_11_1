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

        [XmlIgnore] public Enterprise Enterprise { set; get; }
    }
}
