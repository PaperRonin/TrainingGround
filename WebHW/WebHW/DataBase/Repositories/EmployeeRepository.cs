using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebHW.Services;

namespace WebHW.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        private List<Employee> Employees { get; }
        private WebHwDbContext DbContext { get; }
        public EmployeeRepository()
        {
            DbContext = new WebHwDbContext();
            Employees = DbContext.Employees.Include(e => e.ProjectEmployees).ThenInclude(pe => pe.Project).ToList();
        }

        public IEnumerable<Employee> ListEmployees()=> Employees;

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

        public Employee Find(int id) => Employees.Find(employee => employee.Id == id);

        public void Remove(int id)
        {
            var employeeToDelete = Employees.Find(employee => employee.Id == id);
            DbContext.Employees.Remove(employeeToDelete);
            DbContext.SaveChanges();
        }

    }
}