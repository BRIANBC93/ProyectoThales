using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CalculateSalary
    {
        /// <summary>
        /// Calculation and mapping of the annual salary for all employees
        /// </summary>
        /// <param name="Empl"></param>
        /// <returns></returns>
        public List<Employees.Data> CalculateAnualSalary(List<Employees.Data> Empl)
        {
            List<Employees.Data> ResEmpl = new List<Employees.Data>();

            foreach (var item in Empl)
            {
                item.Employee_anual_Salary = item.EmployeeSalary * 12;
                ResEmpl.Add(item);
            }

            return ResEmpl;
        }

        /// <summary>
        /// Calculation and mapping of the annual salary
        /// </summary>
        /// <param name="Empl"></param>
        /// <returns></returns>
        public Employees.Data CalculateAnualSalary(Employees.Data Empl)
        {
            if(Empl != null)
            {
                Empl.Employee_anual_Salary = Empl.EmployeeSalary * 12;
            }
            return Empl;
        }
    }
}
