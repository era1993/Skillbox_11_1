using EntertpriseIS.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
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
                department => HighLevelDepartment = (department as DepartmentViewModel).Name,
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
