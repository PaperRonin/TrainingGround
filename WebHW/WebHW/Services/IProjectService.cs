﻿using System.Collections.Generic;

namespace WebHW.Services
{
    public interface IProjectService
    {
        public IEnumerable<Project> ListProjects();
        public string Add(Project project);
        public Project Find(int id);
        public void Remove(int id);

    }
}