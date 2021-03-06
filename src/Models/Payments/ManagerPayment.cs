using System.Linq;
using static System.Math;

namespace EntertpriseIS.Models
{
    /// <summary>
    /// Способ расчета заработной платы для руководителей
    /// </summary>
    public class ManagerPayment : IPayment
    {
        /// <summary>
        /// Константа коэффициента расчета заработной платы
        /// </summary>
        public const double PaymentCoefficient = 0.15;
        /// <summary>
        /// Константа минимального размера зарплаты
        /// </summary>
        public const double PaymentMinimal = 1300;
        /// <summary>
        /// Включать ли в расчет заработную плату сотрудников дочерних подразделений
        /// </summary>
        public static bool IncludeChildDepartments = false;

        /// <summary>
        /// Наименование подразделения, которым руководит сотрудник
        /// </summary>
        private Department _department;
        public ManagerPayment(Department department)
        {
            _department = department;
        }

        /// <summary>
        /// Реализация метода расчета зарплаты
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            double sumPayment = 0;
            if (IncludeChildDepartments)
            {
                foreach (Person person in _department.EnumeratePersons())
                {
                    if (!(person.Position is ManagerPosition))
                        sumPayment += person.Position.Payment.Calculate();
                }
            }
            else
            {
                foreach (Person person in _department.Persons)
                {
                    if (!(person.Position is ManagerPosition))
                        sumPayment += person.Position.Payment.Calculate();
                }
            }
            return Max(PaymentMinimal, sumPayment * PaymentCoefficient);
        }
    }
}
