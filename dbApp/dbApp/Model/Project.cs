using System;
using System.Collections.Generic;
using System.Linq;

namespace dbApp.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public string Executor { get; set; }
        public Employee Manager => ProjectEmployees.First().Employee;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint Priority { get; set; }
        public List<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    }
}