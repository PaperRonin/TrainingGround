using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public IEnumerable<Project> Projects
        {
            get
            {
                var list = new List<Project>();
                foreach (var pe in ProjectEmployees)
                {
                    list.Add(pe.Project);
                }

                return list;
            }
        }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
