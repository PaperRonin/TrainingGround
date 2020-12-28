using System;
using Microsoft.EntityFrameworkCore;
using WebHW.Models;

namespace WebHW.DataBase
{
    public interface IWebHWContext: IDisposable
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        int SaveChanges();
    
    }
}