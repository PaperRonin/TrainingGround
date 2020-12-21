using System;
using System.Collections.Generic;

#nullable disable

namespace WebHW
{
    public  class Employee
    {
        public Employee()
        {
            ProjectEmployees = new HashSet<ProjectEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
