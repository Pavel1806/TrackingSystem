using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrackingSystem.DAL.Context;
using TrackingSystem.DAL.Interfaces;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void Create(User user)
        {

            _dbContext.Add(user);
        }

        public void Delete(User user)
        {
            _dbContext.Remove(user);
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.OrderBy(x => x.Id).ToList<User>();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            _dbContext.Update(user);
        }
    }
}
