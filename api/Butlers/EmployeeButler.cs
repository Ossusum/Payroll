using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.api.Butlers.Interfaces;
using WebApplication8.api.Model;
using WebApplication8.api.Repositories;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.api.Butlers
{
    public class EmployeeButler : IEmployeeButler
    {

        public IEmployeeRepository _employeeRepository;
        public IDependentRepository _dependentRepository;

        public EmployeeButler(IEmployeeRepository employeeRepository, IDependentRepository dependentRepository)
        {
            _dependentRepository = dependentRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetListOfEmployees()
        {
            return await _employeeRepository.GetListOfEmployees();
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }
        public async Task AddEmployee(Employee employee)
        {
            int employeeId = await _employeeRepository.AddEmployee(employee);
            if (employee.Dependents.Count() > 0)
            {
                foreach (var dependent in employee.Dependents)
                {
                    await _dependentRepository.AddDependent(dependent, employeeId);
                }

            }
        }
        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
            if (employee.Dependents.Count() > 0)
            {
                foreach (var dependent in employee.Dependents)
                {
                    if (dependent.ID == 0)
                    {
                        await _dependentRepository.AddDependent(dependent, employee.ID);
                    }
                    else
                    {
                        await _dependentRepository.UpdateDependents(dependent);
                    }
                    
                }
                
            }
        }
        public async Task DeleteEmployee(int employeeId)
        {
       
            await _dependentRepository.RemoveEmployeeDependents(employeeId);
            await _employeeRepository.DeleteEmployee(employeeId);
        }

        public async Task DeleteDependent(int id)
        {
            await _dependentRepository.RemoveDependent(id);
        }
    }
}
