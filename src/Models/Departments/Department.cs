using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Базовый класс, описывающий некое подразделение
    /// </summary>
    public class Department : INotifyPropertyChanged
    {
        private string _highLevelDepartment;
        private ICommand _departmentSetCommand = null;
        public Department() : this(null, null) { }
        public Department(string name, string highLevelDepartment)
        {
            Name = name;
            HighLevelDepartment = highLevelDepartment;
            _departmentSetCommand = new ActionCommand(
                department => HighLevelDepartment = (department as Department).Name,
                _ => true);
        }

        /// <summary>
        /// Список дочерних подразделений
        /// </summary>
        [XmlIgnore]
        public virtual ObservableCollection<Department> Departments
        {
            get
            {
                return new ObservableCollection<Department>( Enterprise.Current.Departments.Where(x => x.HighLevelDepartment == Name));
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

        [XmlIgnore] public ICommand HighLevelDepartmentSetCommand => _departmentSetCommand;
        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Подраздаление в состав которого оно входит. Для организации долнобыть равно null
        /// </summary>
        public string HighLevelDepartment { set { _highLevelDepartment = value; RaisePropertyChanged("HighLevelDepartment"); } get { return _highLevelDepartment; } }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property) => PropertyChanged(this, new PropertyChangedEventArgs(property));

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
