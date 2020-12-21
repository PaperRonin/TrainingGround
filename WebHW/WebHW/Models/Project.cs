﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebHW
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

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}