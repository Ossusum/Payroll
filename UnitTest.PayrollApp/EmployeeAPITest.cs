using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.api;
using WebApplication8.api.Butlers;
using WebApplication8.api.Butlers.Interfaces;
using WebApplication8.api.Model;
using WebApplication8.api.Repositories.Interfaces;

namespace UnitTest.PayrollApp
{
    [TestClass]
    public class EmployeeAPITest
    {
        
        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_GetEmployees_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.GetListOfEmployees();

            //Assert
            A.CallTo(() => employeeRepository.GetListOfEmployees()).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_GetEmployee_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.GetEmployee(1);

            //Assert
            A.CallTo(() => employeeRepository.GetEmployee(1)).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_AddEmployee_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>()};
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.AddEmployee(employee);

            //Assert
            A.CallTo(() => employeeRepository.AddEmployee(employee)).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_UpdateEmployee_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>() };
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.UpdateEmployee(employee);

            //Assert
            A.CallTo(() => employeeRepository.UpdateEmployee(employee)).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_RemoveEmployeeDependents_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>() };
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.DeleteEmployee(employee.ID);

            //Assert
            A.CallTo(() => dependentRepository.RemoveEmployeeDependents(employee.ID)).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_DeleteEmployee_Once()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>() };
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);

            //Act
            await employeeButler.DeleteEmployee(employee.ID);

            //Assert
            A.CallTo(() => employeeRepository.DeleteEmployee(employee.ID)).MustHaveHappened();
        }

        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_Update_Exactly()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>() };
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);
            employee.Dependents.ToList().ForEach(dependent => dependent.ID = 0);
            //Act
            await employeeButler.UpdateEmployee(employee);

            //Assert
            A.CallTo(() => dependentRepository.UpdateDependents(employee.Dependents[0]))
                .MustNotHaveHappened();
        }
        [TestMethod]
        public async Task EmployeeButler_Calls_EmployeeRepository_AddDependent_Exactly()
        {
            //Arrange
            var employeeRepository = A.Fake<IEmployeeRepository>();
            var dependentRepository = A.Fake<IDependentRepository>();
            var employee = new Employee() { ID = A.Dummy<int>(), Dependents = A.CollectionOfFake<Dependent>(3), FirstName = A.Dummy<string>() };
            var employeeButler = new EmployeeButler(employeeRepository, dependentRepository);
            employee.Dependents.ToList().ForEach(dependent => dependent.ID = 1);
            //Act
            await employeeButler.UpdateEmployee(employee);

            //Assert
            A.CallTo(() => dependentRepository.AddDependent(employee.Dependents[0], employee.ID))
                .MustNotHaveHappened();
        }
    }
}
