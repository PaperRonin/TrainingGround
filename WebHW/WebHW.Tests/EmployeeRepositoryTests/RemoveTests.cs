using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Models;
using WebHW.Tests.Factories;

namespace WebHW.Tests.EmployeeRepositoryTests
{
    public class RemoveTests
    {
        private Mock<DbSet<Employee>> EmployeeMockSet;
        private Mock<IWebHWContext> MockContext;
        private EmployeeRepository EmployeeService;
        [SetUp]
        public void Setup()
        {
            var setupFactory = new MockSetupFactory();
            EmployeeMockSet = setupFactory.EmployeeMockSet;
            MockContext = setupFactory.MockContext;
            EmployeeService = new EmployeeRepository(MockContext.Object);
        }

        [Test]
        public void Remove_ExistingEmployee_ReturnsEmployee()
        {
            int id = 2;
            
            EmployeeService.Remove(id);
            
            EmployeeMockSet.Verify(m => m.Remove(It.Is<Employee>(employee => employee.Id == id)), Times.Once);
            MockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
        
        [Test]
        public void Remove_NonExistingEmployee_DoesNothing()
        {
            int id = -4;
            
            EmployeeService.Remove(id);
            
            EmployeeMockSet.Verify(m => m.Remove(It.Is<Employee>(employee => employee.Id == id)), Times.Never);
            MockContext.Verify(m => m.SaveChanges(), Times.Never);
        }
    }
}