using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication8.api.Butlers;
using WebApplication8.api.Butlers.Interfaces;

namespace WebApplication8.api.Controllers
{
    public class CompanyController : ApiController
    {
        private ICompanyButler _companyButler;

        public CompanyController(ICompanyButler companyButler)
        {
            _companyButler = companyButler;
        }

        // GET: Company
        public async Task<Company> Get()
        {
            try
            {
                return await _companyButler.GetCompanyDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST api/<controller>
        public async Task Post([FromBody] Company company)
        {
            try
            {
                await _companyButler.UpdateCompanyDetails(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}