using System.Collections.ObjectModel;
using System.Linq;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс организации, основан на базовом классе подразделаения
    /// </summary>
    public class Enterprise : Department
    {
        //private static Enterprise _currentEnterprise;

        public Enterprise() : base(null, null) { }

        public Department DepartmentByName(string name) => Departments.Single(x => x.Name == name);
        /// <summary>
        /// Список всех подразделений в организации
        /// </summary>
        public override ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        /// <summary>
        /// Список всех сотрудников организации
        /// </summary>
        public override ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();
    }
}
