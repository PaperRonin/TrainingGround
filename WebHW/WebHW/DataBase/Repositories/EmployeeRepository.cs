using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebHW.Models;
using WebHW.Services;

namespace WebHW.DataBase.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        private IWebHWContext DbContext { get; }
        public EmployeeRepository(IWebHWContext context)
        {
            DbContext = context;
        }

        public IEnumerable<Employee> ListEmployees() => DbContext.Employees.ToList();
        public string Add(Employee employee)
        {
            try
            {
                if (DbContext.Employees.Any(x => x.Id == employee.Id))
                {
                    throw (new Exception("Employee with such id already exists"));
                }
                var t = DbContext.Employees.Add(employee);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "OK";
        }

        public Employee Find(int id) =>
            DbContext.Employees
                .Include(e => e.ProjectEmployees.Where(pe => pe.EmployeeId == id))
                .ThenInclude(pe => pe.Project)
                .FirstOrDefault(employee => employee.Id == id);

        public void Remove(int id)
        {
            var employeeToDelete = DbContext.Employees.FirstOrDefault(employee => employee.Id == id);
            if (employeeToDelete == null) return;
            DbContext.Employees.Remove(employeeToDelete);
            DbContext.SaveChanges();
        }

    }
}