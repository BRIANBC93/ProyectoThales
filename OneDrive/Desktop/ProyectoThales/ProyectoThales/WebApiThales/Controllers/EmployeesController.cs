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
        [HttpGet("~/SearchEmployeeId")]
        public Employees.Data SearchEmployeeId(int Id)
        {
            DataAccessLayer.Connection Data = new DataAccessLayer.Connection();
            return Data.SearchEmployeeId(Id);
        }

        [HttpGet("~/SearchEmployees")]
        public List<Employees.Data> SearchEmployees()
        {
            DataAccessLayer.Connection Data = new DataAccessLayer.Connection();
            return Data.SearchEmployees();
        }
    }
}
