using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Models;
using WebHW.Tests.Factories;

namespace WebHW.Tests.ProjectRepositoryTests
{
    public class AddTests
    {
        private Mock<DbSet<Project>> ProjectMockSet;
        private Mock<IWebHWContext> MockContext;
        private ProjectRepository ProjectService;
        [SetUp]
        public void Setup()
        {
            var setupFactory = new MockSetupFactory();
            ProjectMockSet = setupFactory.ProjectMockSet;
            MockContext = setupFactory.MockContext;
            ProjectService = new ProjectRepository(MockContext.Object);
        }

        [Test]
        public void Add_NewEmployee_ReturnsOk()   
        {
            var projectToAdd = new Project() {Name = "Dutch Van Der Linde"};
            var response = ProjectService.Add(projectToAdd);
            
            ProjectMockSet.Verify(m => m.Add(It.Is<Project>(project => project == projectToAdd)), Times.Once);
            MockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("OK", response);
        }
        
        [Test]
        public void Add_ExistingEmployee_ReturnsException()
        {
            var projectToAdd = new Project() {Id =  2};
            var response = ProjectService.Add(projectToAdd);
            
            ProjectMockSet.Verify(m => m.Add(It.Is<Project>(project => project == projectToAdd)), Times.Never);
            MockContext.Verify(m => m.SaveChanges(), Times.Never);
            Assert.AreEqual("Project with such id already exists", response);
        }
    }
}