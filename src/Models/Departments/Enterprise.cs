using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Класс организации, основан на базовом классе подразделаения
    /// </summary>
    public class Enterprise : Department
    {
        private static Enterprise _currentEnterprise;
        private ICommand _commandNewPerson = null;
        private ICommand _commandNewDepartment = null;
        private ICommand _commandUpdatePayment = null;

        public Enterprise() : base(null,null)
        {
            _commandNewDepartment = new ActionCommand(
                _ => Departments.Add(new Department($"Департамент №{Departments.Count + 1}", Name)),
                _ => true);
            _commandNewPerson = new ActionCommand(
                _ => Persons.Add(new Person($"Сотрудник №{Persons.Count + 1}")),
                _ => true);
            _commandUpdatePayment = new ActionCommand(
                _ => RefreshPayments(),
                _ => true);
        }

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

        [XmlIgnore] public ICommand NewPersonCommand => _commandNewPerson;
        [XmlIgnore] public ICommand NewDepartmentCommand => _commandNewDepartment;
        [XmlIgnore] public ICommand UpdatePaymentCommand => _commandUpdatePayment;

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
