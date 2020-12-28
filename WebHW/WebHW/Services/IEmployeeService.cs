using System.Collections.Generic;
using WebHW.Models;

namespace WebHW.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> ListEmployees();
        public string Add(Employee employee);
        public Employee Find(int id);
        public void Remove(int id); 
    }
}