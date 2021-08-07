using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication8.api.Model;
using System.Data;
using System.Threading.Tasks;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IDependentRepository _dependentRepository;
        public EmployeeRepository(IDependentRepository dependentRepository)
        {
            _dependentRepository = dependentRepository;
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            var sql = @"
                INSERT INTO [dbo].[Employee] ([FirstName], [LastName], [Wage], [Title]) 
                VALUES ( @FirstName, @LastName, @Wage, @Title)
                
                SELECT CAST(SCOPE_IDENTITY() as int)
            ";
       
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                return await conn.ExecuteScalarAsync<int>(sql, employee);
            }
        }

        public async Task<IEnumerable<Employee>> GetListOfEmployees()
        {
            var sql = @"
                SELECT *
                FROM dbo.Employee
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                return await conn.QueryAsync<Employee>(sql);
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee result;
            var sql = @"
                SELECT *
                FROM dbo.Employee
                WHERE ID = @ID
            ";
            
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                result = await conn.QueryFirstOrDefaultAsync<Employee>(sql, new { ID = id } );
                result.Dependents = await _dependentRepository.GetListOfDependents(id);

            }
            return result;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var sql = @"
                DELETE dbo.Employee
                WHERE ID = @ID
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, new { ID = employeeId});
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var sql = @"
                UPDATE dbo.Employee
                SET FirstName = @FirstName,
	                LastName = @LastName,
	                HireDate = @HireDate,
	                Wage = @Wage,
	                Title = @Title
                WHERE ID = @ID

            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, employee);
            }
        }



    }
}