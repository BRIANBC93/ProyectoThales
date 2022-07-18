using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiThales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Search Employee by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("~/SearchEmployeeId")]
        public Employees.Data SearchEmployeeId(int Id)
        {
            DataAccessLayer.Connection Data = new DataAccessLayer.Connection();
            return Data.SearchEmployeeId(Id);
        }

        /// <summary>
        /// Search for all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/SearchEmployees")]
        public List<Employees.Data> SearchEmployees()
        {
            DataAccessLayer.Connection Data = new DataAccessLayer.Connection();
            return Data.SearchEmployees();
        }
    }
}
