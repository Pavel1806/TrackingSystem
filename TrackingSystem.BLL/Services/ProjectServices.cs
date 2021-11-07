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
    public class ProjectServices : IServices<ProjectDTO>
    {
        IUnitOfWork db;
        public ProjectServices(IUnitOfWork efUnitOfWork)
        {
            db = efUnitOfWork;
        }

        public void Create(ProjectDTO t)
        {
            var project = new Project
            {
                 Name=t.Name
            };

            db.projects.Create(project);
            db.Save();
        }

        public void Delete(ProjectDTO t)
        {
            var project = new Project
            {
                Name = t.Name
            };

            db.projects.Delete(project);
            db.Save();
        }
        public void Update(ProjectDTO t)
        {
            var project = db.projects.GetById(t.Id);

            db.projects.Delete(project);

            db.Save();
        }

        public List<ProjectDTO> GetAll()
        {
            var map = new MapperConfiguration(x => x.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return map.Map<List<Project>, List<ProjectDTO>>(db.projects.GetAll());
        }

        public ProjectDTO GetById(int id)
        {
            var project = db.projects.GetById(id);
            
            var projectTasks = db.projectTasks.GetAllProjectId(id);
            var listTasks = new List<ProjectTaskDTO>();
            foreach (var item in projectTasks)
            {
                User user = db.users.GetById(item.UserId);

                listTasks.Add(new ProjectTaskDTO { 
                 Id= item.Id,
                 Priority= item.Priority,
                 Topic=item.Topic,
                 Type=item.Type,
                 userId = item.UserId,
                 userDTO =  new UserDTO { Id = user.Id, Name = user.Name, SerName= user.SerName}
                });
            }

            var projectDTO = new ProjectDTO
            {
                Name = project.Name,
                Tasks= listTasks
            };

            return projectDTO;
        }

        
    }
}
