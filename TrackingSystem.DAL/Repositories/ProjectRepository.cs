using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackingSystem.DAL.Context;
using TrackingSystem.DAL.Interfaces;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Repositories
{
    class ProjectRepository : IRepository<Project>
    {
        private readonly AppDbContext _dbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void Create(Project project)
        {

            _dbContext.Add(project);
        }

        public void Delete(Project project)
        {
            _dbContext.Remove(project);
        }

        public List<Project> GetAll()
        {
            return _dbContext.Projects.OrderBy(x => x.Id).ToList<Project>();
        }

        public Project GetById(int id)
        {
            var t = _dbContext.Projects.Where(x => x.Id == id).FirstOrDefault();

            var u = t.Tasks;
            return t;
        }

        public void Update(Project project)
        {
            _dbContext.Update(project);
        }
    }
}
