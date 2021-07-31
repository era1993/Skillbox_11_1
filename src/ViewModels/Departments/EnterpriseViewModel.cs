using EntertpriseIS.Models;
using System;
using System.Collections.Specialized;
using System.Windows.Input;

namespace EntertpriseIS.ViewModels
{
    public class EnterpriseViewModel : DepartmentViewModel
    {
        private Enterprise _enterprise;
        private ICommand _commandNewPerson = null;
        private ICommand _commandNewDepartment = null;
        private ICommand _commandUpdatePayment = null;

        public ICommand NewPersonCommand => _commandNewPerson;
        public ICommand NewDepartmentCommand => _commandNewDepartment;
        public ICommand UpdatePaymentCommand => _commandUpdatePayment;

        /// <summary>
        /// Для всех сотрудников обновляет информацию о способе расчета заработной платы
        /// </summary>
        public void RefreshPayments()
        {
            foreach (PersonViewModel p in Persons)
                p.Position.RefreshPayment();
        }
        public EnterpriseViewModel(Enterprise enterprise) : base(enterprise)
        {
            _enterprise = enterprise;
            Departments.CollectionChanged += Departments_CollectionChanged;
            Persons.CollectionChanged += Persons_CollectionChanged;
            _commandNewDepartment = new ActionCommand(
                _ => Departments.Add(new DepartmentViewModel(new Department($"Департамент №{Departments.Count + 1}", Name) { Enterprise = enterprise })),
                _ => _enterprise != null);
            _commandNewPerson = new ActionCommand(
                _ => Persons.Add(new PersonViewModel(new Person($"Сотрудник №{Persons.Count + 1}") { Enterprise = enterprise })),
                _ => _enterprise != null);
            _commandUpdatePayment = new ActionCommand(
                _ => RefreshPayments(),
                _ => _enterprise != null);
        }

        private void Persons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (PersonViewModel d in e.NewItems)
                        if (d != null)
                            _enterprise.Persons.Add(d.Value);
                    break;
                default: throw new NotImplementedException();
            }
        }

        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (DepartmentViewModel d in e.NewItems)
                        if (d != null)
                            _enterprise.Departments.Add(d.Value);
                    break;
                default: throw new NotImplementedException();
            }
        }
    }
}
