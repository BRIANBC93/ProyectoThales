using Newtonsoft.Json;
using System.Collections.Generic;

namespace Entities
{
    public class Employees
    {

        public partial class ValuesList
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("Data")]
            public List<Data> Data { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }


        public partial class Values
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("Data")]
            public Data Data { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("employee_name")]
            public string EmployeeName { get; set; }

            [JsonProperty("employee_salary")]
            public long EmployeeSalary { get; set; }

            [JsonProperty("Employee_anual_Salary")]
            public long Employee_anual_Salary { get; set; }

            [JsonProperty("employee_age")]
            public long EmployeeAge { get; set; }

            [JsonProperty("profile_image")]
            public string ProfileImage { get; set; }
        }
    }
}
