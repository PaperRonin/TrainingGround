using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebHW.Models;
using WebHW.Services;

namespace WebHW.DataBase.Repositories
{
    public class ProjectRepository : IProjectService
    {
        private IWebHWContext DbContext { get; }

        public ProjectRepository(IWebHWContext context)
        {
            DbContext = context;
        }

        public IEnumerable<Project> ListProjects() => DbContext.Projects.ToList();

        public string Add(Project project)
        {
            try
            {
                if (DbContext.Employees.Any(x => x.Id == project.Id))
                {
                    throw (new Exception("Project with such id already exists"));
                }

                DbContext.Projects.Add(project);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "OK";
        }

        public Project Find(int id) => DbContext.Projects
            .Include(e => e.ProjectEmployees.Where(pe => pe.ProjectId == id)).ThenInclude(pe => pe.Employee)
            .FirstOrDefault(project => project.Id == id);

        public void Remove(int id)
        {
            var projectToDelete = DbContext.Projects.FirstOrDefault(employee => employee.Id == id);
            if (projectToDelete == null) return;
            DbContext.Projects?.Remove(projectToDelete);
            DbContext.SaveChanges();
        }
    }
}