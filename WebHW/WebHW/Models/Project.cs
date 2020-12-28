using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace WebHW.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectEmployees = new HashSet<ProjectEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public string Executor { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Priority { get; set; }
        [NotMapped]
        public IEnumerable<Employee> Employees
        {
            get
            {
                return ProjectEmployees.Select(pe => pe.Employee).ToList();
            }
        }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
