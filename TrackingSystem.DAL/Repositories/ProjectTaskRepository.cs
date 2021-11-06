using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrackingSystem.DAL.Context;
using TrackingSystem.DAL.Interfaces;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Repositories
{
    class ProjectTaskRepository : IRepository<ProjectTask>
    {

        private readonly AppDbContext _dbContext;

        public ProjectTaskRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;

            
        }

        public void Create(ProjectTask task)
        {

            _dbContext.Add(task);
        }

        public void Delete(ProjectTask task)
        {
            _dbContext.Remove(task);
        }

        public List<ProjectTask> GetAll()
        {
            //var t =  _dbContext.ProjectTasks.OrderBy(x => x.Id).ToList<ProjectTask>();
            //var y = _dbContext.Projects.
            var t = _dbContext.ProjectTasks.Join(_dbContext.Projects, t => t.ProjectId, s => s.Id,
                (t, s) => new 
                {
                     Id = t.Id,
                     Priority=t.Priority,
                     Topic=t.Topic,
                     Type= t.Type,
                     Project = new Project { Id=s.Id, Name=s.Name},
                     id=t.UserId
                     
                }).Join(_dbContext.Users, t=>t.id, s=>s.Id,
                (t,s)=> new ProjectTask
                {
                     Id=t.Id,
                     Priority=t.Priority,
                     Topic=t.Topic,
                     Type=t.Type,
                     project=t.Project,
                     user=new User { Id=s.Id, Name=s.Name, SerName=s.SerName}
                }
                ).ToList();

            return t;
        }

        public ProjectTask GetById(int id)
        {
            return _dbContext.ProjectTasks.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(ProjectTask task)
        {
            _dbContext.Update(task);
        }

        //public void Join ()
        //{
        //    var result = _dbContext.ProjectTasks.Join(_dbContext.Projects, t => t.project.Id, s => s.Id,
        //        (t, s) => new
        //        {
        //            Priority = t.Priority,
        //            Topic = t.Topic,
        //            Type=t.Type,
        //            Id=t.Id,
        //            ProjectName = s.Name,

        //        }

        //    );
        //}
    }
}
