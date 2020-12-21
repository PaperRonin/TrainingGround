using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebHW.Services;

namespace WebHW.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {   
        private WebHwDbContext DbContext { get; }
        public EmployeeRepository(WebHwDbContext context)
        {
            DbContext = context;
        }

        public IEnumerable<Employee> ListEmployees() => DbContext.Employees.ToList();
        public string Add(Employee employee)
        {
            try
            {
                //project validation;
                //throw (new Exception("Message"));
                DbContext.Employees.Add(employee);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "OK";
        }

        public Employee Find(int id) => DbContext.Employees.
            Include(e => e.ProjectEmployees).
            ThenInclude(pe => pe.Project).
            FirstOrDefault(employee => employee.Id == id);

        public void Remove(int id)
        {
            var employeeToDelete = DbContext.Employees.FirstOrDefault(employee => employee.Id == id);
            if (employeeToDelete == null) return;
            DbContext.Employees.Remove(employeeToDelete);
            DbContext.SaveChanges();
        }

    }
}