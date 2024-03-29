﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entities;
using BusinessLogicLayer;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class Connection
    {
        String BaseUrl = "http://dummy.restapiexample.com";
        /// <summary>
        /// Search for all employees,connect with test apis
        /// </summary>
        /// <returns></returns>
        public List<Employees.Data> SearchEmployees()
        {
            Employees.ValuesList EmpInfo = new Employees.ValuesList();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res =  client.GetAsync("api/v1/employees").Result;

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse =  Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Employees.ValuesList>(EmpResponse);
                    EmpInfo.Data = new CalculateSalary().CalculateAnualSalary(EmpInfo.Data);
                }
                else
                {
                    return _ = ValidationState();
                }
                return EmpInfo.Data;
            }
        }


        /// <summary>
        /// Search Employee by Id,connect with test apis
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Employees.Data SearchEmployeeId(int Id)
        {
            Employees.Values EmpInfo = new Employees.Values();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("api/v1/employee/" + Id).Result;

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Employees.Values>(EmpResponse);
                    EmpInfo.Data = new CalculateSalary().CalculateAnualSalary(EmpInfo.Data);
                }
                else
                {
                    return _ = ValidationState(Id);
                }
            }

            return EmpInfo.Data;
        }

        /// <summary>
        /// Validate the status of the connection with the test apis and try again
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private Employees.Data  ValidationState(int Id)
        {
            Employees.Data state;
            state= SearchEmployeeId(Id);
            if (state == null)
            {
                state = SearchEmployeeId(Id);
            }

            return state;
        }

        /// <summary>
        /// Validate the status of the connection with the test apis and try again
        /// </summary>
        /// <returns></returns>
        private List<Employees.Data> ValidationState()
        {
            List<Employees.Data> state;
            state = SearchEmployees();
            if (state == null)
            {
                state =SearchEmployees();
            }

            return state;
        }

    }
}
