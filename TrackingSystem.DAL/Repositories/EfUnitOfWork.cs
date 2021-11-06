using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrackingSystem.DAL.Context;
using TrackingSystem.DAL.Interfaces;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {

        private IRepository<User> userRepository;
        private IRepository<Project> projectRepository;
        private IRepository<ProjectTask> projectTaskRepository;
        private AppDbContext db;

        public EfUnitOfWork(DbContextOptions<AppDbContext> dbContext)
        {
            db = new AppDbContext(dbContext);

            //db.Add(new ProjectTask
            //{
            //    project = db.Projects.,
            //    Priority = "Priority1",
            //    Topic = "Topic1",
            //    Type = "Type1",
            //    user = new User { Name = "UserName1", SerName = "UserSerName1" }
            //});
            //db.Add(new ProjectTask
            //{
            //    project = new Project { Name = "NameProject2" },
            //    Priority = "Priority2",
            //    Topic = "Topic2",
            //    Type = "Type2",
            //    user = new User { Name = "UserName2", SerName = "UserSerName2" }
            //});
            //db.Add(new ProjectTask
            //{
            //    project = new Project { Name = "NameProject3" },
            //    Priority = "Priority3",
            //    Topic = "Topic3",
            //    Type = "Type3",
            //    user = new User { Name = "UserName3", SerName = "UserSerName3" }
            //});

            Save();

        }

        public IRepository<User> users 
        { 
            get 
            { 
            if(userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            } 
        }
        public IRepository<Project> projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }
        public IRepository<ProjectTask> projectTasks
        {
            get
            {
                if (projectTaskRepository == null)
                    projectTaskRepository = new ProjectTaskRepository(db);
                return projectTaskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
