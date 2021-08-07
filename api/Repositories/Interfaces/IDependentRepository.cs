using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.api.Model;

namespace WebApplication8.api.Repositories.Interfaces
{
    public interface IDependentRepository
    {
        Task RemoveEmployeeDependents(int employeeId);
        Task RemoveDependent(int dependentId);
        Task UpdateDependents(Dependent dependent);
        Task AddDependent(Dependent dependent, int employeeID);
        Task<IList<Dependent>> GetListOfDependents(int employeeID);
    }
}
