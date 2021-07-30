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
    public class Department
    {
        public Department() : this(null, null) { }
        public Department(string name, string highLevelDepartment)
        {
            Name = name;
            HighLevelDepartment = highLevelDepartment;
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

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Подраздаление в состав которого оно входит. Для организации долнобыть равно null
        /// </summary>
        public string HighLevelDepartment { set; get; }

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


    /// <summary>
    /// Базовый класс, описывающий некое подразделение
    /// </summary>
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        public Department Value { get; private set; }
        private ICommand _departmentSetCommand = null;
        public DepartmentViewModel(Department department)
        {
            Value = department;
            _departmentSetCommand = new ActionCommand(
                department => HighLevelDepartment = (department as Department).Name,
                _ => true);
            Departments = new ObservableCollection<DepartmentViewModel>(Value.Departments.Select(x => new DepartmentViewModel(x)));
            Persons = new ObservableCollection<PersonViewModel>(Value.Persons.Select(x => new PersonViewModel(x)));
        }

        /// <summary>
        /// Список дочерних подразделений
        /// </summary>
        public virtual ObservableCollection<DepartmentViewModel> Departments { get; }

        /// <summary>
        /// Список сотрудников данного подразделения
        /// </summary>
        public virtual ObservableCollection<PersonViewModel> Persons { get; }

        public ICommand HighLevelDepartmentSetCommand => _departmentSetCommand;
        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string Name { set { Value.Name = value; RaisePropertyChanged("Name"); } get { return Value.Name; } }

        /// <summary>
        /// Подраздаление в состав которого оно входит. Для организации долнобыть равно null
        /// </summary>
        public string HighLevelDepartment { set { Value.HighLevelDepartment = value; RaisePropertyChanged("HighLevelDepartment"); } get { return Value.HighLevelDepartment; } }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string property) => PropertyChanged(this, new PropertyChangedEventArgs(property));

    }
}
