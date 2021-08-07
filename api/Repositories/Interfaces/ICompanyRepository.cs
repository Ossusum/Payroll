using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.api.Controllers;

namespace WebApplication8.api.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task UpdateCompanyDetails(Company company);
        Task<Company> GetCompanyDetails();
    }
}
