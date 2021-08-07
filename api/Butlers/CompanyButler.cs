using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication8.api.Butlers.Interfaces;
using WebApplication8.api.Controllers;
using WebApplication8.api.Repositories;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.api.Butlers
{
    public class CompanyButler : ICompanyButler
    {
        public ICompanyRepository _companyRepository;

        public CompanyButler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetCompanyDetails()
        {
            return await _companyRepository.GetCompanyDetails();
        }
        public async Task UpdateCompanyDetails(Company company)
        {
            await _companyRepository.UpdateCompanyDetails(company);
        }
    }
}