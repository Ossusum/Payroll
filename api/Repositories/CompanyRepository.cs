using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication8.api.Controllers;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.api.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public async Task UpdateCompanyDetails(Company company)
        {
            var sql = @"
                UPDATE dbo.Company
                SET Name = @Name,
	                CostPerEmployee = @CostPerEmployee,
	                CostPerDependent = @CostPerDependent,
	                PaySchedule = @PaySchedule,
	                EmployeeDeduction = @EmployeeDeduction,
                    DefaultEmployeeSalary = @DefaultEmployeeSalary

            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, company);
            }
        }

        public async Task<Company> GetCompanyDetails()
        {
            var sql = @"
                SELECT *
                FROM dbo.Company
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                return await conn.QueryFirstOrDefaultAsync<Company>(sql);
            }
        }
    }
}