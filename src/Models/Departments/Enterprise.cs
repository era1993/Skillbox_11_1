using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс организации, основан на базовом классе подразделаения
    /// </summary>
    public class Enterprise : Department
    {
        private static Enterprise _currentEnterprise;

        public Enterprise() : base(null,null)
        { }

        /// <summary>
        /// Статическая ссылка на текущую организацию
        /// </summary>
        public static Enterprise Current
        {
            get => _currentEnterprise;
            set => _currentEnterprise = value;
        }

        /// <summary>
        /// Список всех подразделений в организации
        /// </summary>
        public override ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();


        /// <summary>
        /// Список всех сотрудников организации
        /// </summary>
        public override ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();


        /// <summary>
        /// Для всех сотрудников обновляет информацию о способе расчета заработной платы
        /// </summary>
        public void RefreshPayments()
        {
            foreach (Person p in Persons)
                p.Position.RefreshPayment();
        }
    }
}
