using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Models;
using WebHW.Tests.Factories;

namespace WebHW.Tests.EmployeeRepositoryTests
{
    public class FindTests
    {
        private Mock<IWebHWContext> MockContext;
        private EmployeeRepository EmployeeService;
        [SetUp]
        public void Setup()
        {
            var setupFactory = new MockSetupFactory();
            MockContext = setupFactory.MockContext;
            EmployeeService = new EmployeeRepository(MockContext.Object);
        }

        [Test]
        public void Find_ExistingEmployee_ReturnsEmployee()
        {
            int id = 2;
                
            var employee = EmployeeService.Find(id);
            
            MockContext.Verify(m => m.Employees, Times.Once);
            Assert.AreEqual("secondE", employee.Name);
        }
        
        [Test]
        public void Find_NonExistingEmployee_ReturnsNull()
        {
            int id = -4;

            var employee = EmployeeService.Find(id);
            
            MockContext.Verify(m => m.Employees, Times.Once);
            Assert.AreEqual(null, employee);
        }
        
    }
}