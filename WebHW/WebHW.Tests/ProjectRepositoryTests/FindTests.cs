using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Tests.Factories;

namespace WebHW.Tests.ProjectRepositoryTests
{
    public class FindTests
    {
        private Mock<IWebHWContext> MockContext;
        private ProjectRepository ProjectService;
        [SetUp]
        public void Setup()
        {
            var setupFactory = new MockSetupFactory();
            MockContext = setupFactory.MockContext;
            ProjectService = new ProjectRepository(MockContext.Object);
        }

        [Test]
        public void Find_ExistingEmployee_ReturnsEmployee()
        {
            int id = 2;
                
            var employee = ProjectService.Find(id);
            
            MockContext.Verify(m => m.Projects, Times.Once);
            Assert.AreEqual("secondP", employee.Name);
        }
        
        [Test]
        public void Find_NonExistingEmployee_ReturnsNull()
        {
            int id = -4;

            var employee = ProjectService.Find(id);
            
            MockContext.Verify(m => m.Projects, Times.Once);
            Assert.AreEqual(null, employee);
        }
        
    }
}