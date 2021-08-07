using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication8.api.Model;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.api.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        public async Task UpdateDependents(Dependent dependent)
        {
            var sql = @"
                UPDATE dbo.Dependent
                SET FirstName = @FirstName,
	                LastName = @LastName,
	                Relationship = @Relationship
                WHERE ID = @ID

            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, dependent);
            }
        }

        public async Task AddDependent(Dependent dependent, int employeeID)
        {
            var sql = @"
                INSERT INTO [dbo].[Dependent] ([FirstName], [LastName], [Relationship], [EmployeeID]) 
                VALUES ( @FirstName, @LastName, @Relationship, @EmployeeID)
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, new
                {
                    FirstName = dependent.FirstName,
                    LastName = dependent.LastName,
                    Relationship = dependent.Relationship,
                    EmployeeID = employeeID
                });
            }
        }

        public async Task<IList<Dependent>> GetListOfDependents(int employeeID)
        {
            var sql = @"
                SELECT *
                FROM dbo.Dependent
                WHERE EmployeeID = @EmployeeID
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                return (await conn.QueryAsync<Dependent>(sql, new { EmployeeID = employeeID })).ToList();
            }
        }

        public async Task RemoveEmployeeDependents(int employeeId)
        {
            var sql = @"
                DELETE dbo.Dependent
                WHERE EmployeeID = @EmployeeID
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, new { EmployeeID = employeeId });
            }
        }

        public async Task RemoveDependent(int dependentId)
        {
            var sql = @"
                DELETE dbo.Dependent
                WHERE ID = @ID
            ";

            using (IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(sql, new { ID = dependentId });
            }
        }
    }
}