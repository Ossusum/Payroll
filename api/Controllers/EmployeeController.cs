using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication8.api.Butlers;
using WebApplication8.api.Butlers.Interfaces;
using WebApplication8.api.Model;

namespace WebApplication8.api
{
    public class EmployeeController : ApiController
    {
        private IEmployeeButler _employeeButler;

        public EmployeeController(IEmployeeButler employeeButler)
        {
            _employeeButler = employeeButler;
        }
        // GET api/<controller>
        public async Task<IEnumerable<Employee>> GetAsync()
        {

            try
            {
                return await _employeeButler.GetListOfEmployees();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/<controller>/5
        public async Task<Employee> Get(int id)
        {
            try
            {
                return await _employeeButler.GetEmployee(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/<controller>
        public async Task Post([FromBody] Employee employee)
        {
            try
            {
                await _employeeButler.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5
        public async Task Put([FromBody] Employee employee)
        {
            try
            {
                await _employeeButler.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Employee/Delete")]
        public async Task Delete([FromBody]int id)
        {
            try
            {
                await _employeeButler.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Employee/DeleteDependent")]
        public async Task DeleteDependent([FromBody] int id)
        {
            try
            {
                await _employeeButler.DeleteDependent(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}