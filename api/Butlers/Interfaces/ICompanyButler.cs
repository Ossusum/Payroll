using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.api.Controllers;

namespace WebApplication8.api.Butlers.Interfaces
{
    public interface ICompanyButler
    {
        Task<Company> GetCompanyDetails();
        Task UpdateCompanyDetails(Company company);
    }
}
