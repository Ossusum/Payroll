using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.api.Model;

namespace WebApplication8.api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetListOfEmployees();
        Task<Employee> GetEmployee(int id);
        Task DeleteEmployee(int employeeId);
        Task UpdateEmployee(Employee employee);
        
    }
}
