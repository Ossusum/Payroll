using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.api.Model;

namespace WebApplication8.api.Butlers.Interfaces
{
    public interface IEmployeeButler
    {
        Task<IEnumerable<Employee>> GetListOfEmployees();
        Task<Employee> GetEmployee(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task DeleteDependent(int id);
    }
}
