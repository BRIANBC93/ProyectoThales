using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using BusinessLogicLayer;
using Entities;

namespace UnitTestProjectThales
{
    [TestClass]
    public class BusinessLogicLayerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CalculateAnualSalary()
        {
      
            Employees.Data Data = new Employees.Data();
            Data.Id = 1;
            Data.EmployeeName = "Brian Bernal";
            Data.EmployeeSalary = 9000000;
            Data.EmployeeAge = 28;
            Data.ProfileImage = "";

            Data = new CalculateSalary().CalculateAnualSalary(Data);

            Assert.AreEqual(108000000, Data.Employee_anual_Salary, "Error Calculando el salario Anual");

        }
    }
}
