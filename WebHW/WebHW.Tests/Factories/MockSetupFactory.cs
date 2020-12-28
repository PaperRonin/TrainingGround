using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebHW.DataBase;
using WebHW.Models;

namespace WebHW.Tests.Factories
{
    public class MockSetupFactory
    {
        public Mock<DbSet<Employee>> EmployeeMockSet { get; }
        public Mock<DbSet<Project>> ProjectMockSet { get; }
        public Mock<DbSet<ProjectEmployee>> ProjectEmployeeMockSet { get; }
        public Mock<IWebHWContext> MockContext { get; }

        public MockSetupFactory()
        {
            EmployeeMockSet = MockSetFactory<Employee>.GetMockSet( new List<Employee>
            {
                new() {Id = 1, Name = "firstE"},
                new() {Id = 2, Name = "secondE"},
                new() {Id = 3, Name = "thirdE"},
            });
            ProjectMockSet = MockSetFactory<Project>.GetMockSet(new List<Project>
            {
                new() {Id = 1, Name = "firstP"},
                new() {Id = 2, Name = "secondP"},
                new() {Id = 3, Name = "thirdP"},
            });
            ProjectEmployeeMockSet = MockSetFactory<ProjectEmployee>.GetMockSet(new List<ProjectEmployee>
            {
                new() {EmployeeId = 1, ProjectId = 1},
                new() {EmployeeId = 1, ProjectId = 2},
                new() {EmployeeId = 1, ProjectId = 3},
                new() {EmployeeId = 2, ProjectId = 1},
                new() {EmployeeId = 3, ProjectId = 2},
            });
            
            MockContext = new Mock<IWebHWContext>();
            MockContext.Setup(d => d.Employees).Returns(EmployeeMockSet.Object);
            MockContext.Setup(d => d.Projects).Returns(ProjectMockSet.Object);
            MockContext.Setup(d => d.ProjectEmployees).Returns(ProjectEmployeeMockSet.Object);
        }
    }
}