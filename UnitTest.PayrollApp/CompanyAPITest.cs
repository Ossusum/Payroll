using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WebApplication8.api.Butlers;
using WebApplication8.api.Controllers;
using WebApplication8.api.Repositories.Interfaces;

namespace UnitTest.PayrollApp
{
    [TestClass]
    public class CompanyAPITest
    {
        [TestMethod]
        public async Task CompanyContoller_Calls_CompanyButler_GetCompanyDetails_Once()
        {
            //Arrange
            var companyRepository = A.Fake<ICompanyRepository>();
            var companyButler = new CompanyButler(companyRepository);

            //Act
            await companyButler.GetCompanyDetails();

            //Assert
            A.CallTo(() => companyRepository.GetCompanyDetails()).MustHaveHappened();
        }
        [TestMethod]
        public async Task CompanyContoller_Calls_CompanyButler_UpdateCompanyDetails_Once()
        {
            //Arrange
            var companyRepository = A.Fake<ICompanyRepository>();
            var companyButler = new CompanyButler(companyRepository);
            var company = A.Fake<Company>();

            //Act
            await companyButler.UpdateCompanyDetails(company);

            //Assert
            A.CallTo(() => companyRepository.UpdateCompanyDetails(company)).MustHaveHappened();
        }
    }
}
