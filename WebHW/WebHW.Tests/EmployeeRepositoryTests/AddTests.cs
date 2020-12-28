using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Models;
using WebHW.Tests.Factories;

namespace WebHW.Tests.EmployeeRepositoryTests
{
    public class AddTests
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
        public void Add_NewEmployee_ReturnsOk()   
        {
            var employeeToAdd = new Employee() {Name = "Dutch Van Der Linde"};
            var response = EmployeeService.Add(employeeToAdd);
            
            EmployeeMockSet.Verify(m => m.Add(It.Is<Employee>(employee => employee == employeeToAdd)), Times.Once);
            MockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("OK", response);
        }
        
        [Test]
        public void Add_ExistingEmployee_ReturnsException()
        {
            var employeeToAdd = new Employee() {Id =  2};
            var response = EmployeeService.Add(employeeToAdd);
            
            EmployeeMockSet.Verify(m => m.Add(It.Is<Employee>(employee => employee == employeeToAdd)), Times.Never);
            MockContext.Verify(m => m.SaveChanges(), Times.Never);
            Assert.AreEqual("Employee with such id already exists", response);
        }
    }
}