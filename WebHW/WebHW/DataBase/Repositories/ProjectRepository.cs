using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebHW.Services;

namespace WebHW.Repositories
{
    public class ProjectRepository : IProjectService
    {
        private List<Project> Projects { get; }
        private WebHwDbContext DbContext { get; }

        public ProjectRepository()
        {
            DbContext = new WebHwDbContext();
            Projects = DbContext.Projects.Include(e => e.ProjectEmployees).ThenInclude(pe => pe.Employee).ToList();
        }

        public IEnumerable<Project> ListProjects() => Projects;
        public string Add(Project project)
        {
            try
            {
                //project validation;
                //throw (new Exception("Message"));
                DbContext.Projects.Add(project);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "OK";
        }

        public Project Find(int id) => Projects.Find(project => project.Id == id);

        public void Remove(int id)
        {
            var projectToDelete = Projects.Find(employee => employee.Id == id);
            DbContext.Projects.Remove(projectToDelete);
            DbContext.SaveChanges();
        }

    }
}