using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Базовый класс, описывающий некое подразделение
    /// </summary>
    public class Department 
    {
        public Department() : this(null, null) { }
        public Department(string name, string highLevelDepartment)
        {
            Name = name;
            HiglLevelDepartment = highLevelDepartment;
        }

        /// <summary>
        /// Список дочерних подразделений
        /// </summary>
        [XmlIgnore]
        public virtual ObservableCollection<Department> Departments
        {
            get
            {
                return new ObservableCollection<Department>( Enterprise.Current.Departments.Where(x => x.HiglLevelDepartment == Name));
            }
            set { }
        }


        /// <summary>
        /// Список сотрудников данного подразделения
        /// </summary>
        [XmlIgnore]
        public virtual ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>( Enterprise.Current.Persons.Where(x => x.Position.Department == Name));
            }
            set { }
        }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Подраздаление в состав которого оно входит. Для организации долнобыть равно null
        /// </summary>
        public string HiglLevelDepartment { set; get; }

        /// <summary>
        /// Возвращает перечень всех сотрудников, включая дочерние подразделения
        /// </summary>
        /// <returns></returns>
        public Person[] EnumeratePersons()
        {
            List<Person> list = new List<Person>(Persons);
            foreach (Department dp in Departments)
            {
                list.AddRange(dp.EnumeratePersons());
            }
            return list.ToArray();
        }
    }
}
