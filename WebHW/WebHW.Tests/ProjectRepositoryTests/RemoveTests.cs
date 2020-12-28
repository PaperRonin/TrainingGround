using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebHW.DataBase;
using WebHW.DataBase.Repositories;
using WebHW.Models;
using WebHW.Tests.Factories;

namespace WebHW.Tests.ProjectRepositoryTests
{
    public class RemoveTests
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
        public void Remove_ExistingEmployee_ReturnsEmployee()
        {
            int id = 2;
            
            ProjectService.Remove(id);
            
            ProjectMockSet.Verify(m => m.Remove(It.Is<Project>(project => project.Id == id)), Times.Once);
            MockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
        
        [Test]
        public void Remove_NonExistingEmployee_DoesNothing()
        {
            int id = -4;
            
            ProjectService.Remove(id);
            
            ProjectMockSet.Verify(m => m.Remove(It.Is<Project>(project => project.Id == id)), Times.Never);
            MockContext.Verify(m => m.SaveChanges(), Times.Never);
        }
    }
}