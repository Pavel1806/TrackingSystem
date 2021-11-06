using System;
using System.Collections.Generic;
using System.Text;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> users { get; }
        IRepository<Project> projects { get; }
        IRepository<ProjectTask> projectTasks { get; }
        void Save();
    }
}
