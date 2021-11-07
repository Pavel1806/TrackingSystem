using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrackingSystem.BLL.Interfaces;
using TrackingSystem.BLL.Models;
using TrackingSystem.DAL.Interfaces;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.BLL.Services
{
    public class UserServices : IServices<UserDTO>
    {
        IUnitOfWork db;
        public UserServices(IUnitOfWork efUnitOfWork)
        {
            db = efUnitOfWork;
        }

        public void Create(UserDTO t)
        {
            var user = new User
            {
                Name = t.Name,
                SerName = t.SerName
            };
            db.users.Create(user);
            db.Save();
        }

        public void Delete(UserDTO t)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll()
        {
            var map = new MapperConfiguration(x => x.CreateMap<User, UserDTO>()).CreateMapper();
            return map.Map<List<User>, List<UserDTO>>(db.users.GetAll());
        }

        public UserDTO GetById(int id)
        {
            var user = db.users.GetById(id);
            var tasks = db.projectTasks.GetAllUserId(id); 
            var listTasks = new List<ProjectTaskDTO>();
            foreach (var item in tasks)
            {
                Project project = db.projects.GetById(item.ProjectId);
                listTasks.Add(new ProjectTaskDTO
                {
                    Id = item.Id,
                    Priority = item.Priority,
                    Topic = item.Topic,
                    Type = item.Type,
                    projectId = item.ProjectId,
                    projectDTO = new ProjectDTO { Id = user.Id, Name = user.Name}
                });
            }
            UserDTO userDTO = new UserDTO { Id = user.Id, Name = user.Name, SerName = user.SerName, Tasks = listTasks };

            return userDTO;
        }

        public void Update(UserDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
