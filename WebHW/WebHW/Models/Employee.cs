using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace WebHW.Models
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
                return ProjectEmployees.Select(pe => pe.Project).ToList();
            }
        }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
