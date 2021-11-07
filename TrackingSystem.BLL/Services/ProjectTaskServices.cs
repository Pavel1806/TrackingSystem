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
    public class ProjectTaskServices : IServices<ProjectTaskDTO>
    {
        IUnitOfWork db;
        public ProjectTaskServices(IUnitOfWork efUnitOfWork)
        {
            db = efUnitOfWork;
        }
        public void Create(ProjectTaskDTO t)
        {

            ProjectTask projectTask = null;
            var user = db.users.GetById(t.userId);
            var project = db.projects.GetById(t.projectId);
            if (user != null && project!=null)
            {
                projectTask = new ProjectTask
                {
                    Priority = t.Priority,
                    Topic = t.Topic,
                    Type = t.Type,
                    project = project,
                    user = user,
                    UserId = t.userId,
                    ProjectId = t.projectId
                };
            }

            db.projectTasks.Create(projectTask);
            db.Save();
        }

        public void Delete(ProjectTaskDTO t)
        {
            var projectTask = db.projectTasks.GetById(t.Id);

            db.projectTasks.Delete(projectTask);
            db.Save();
        }

        public List<ProjectTaskDTO> GetAll()
        {
            
            var projectTask = db.projectTasks.GetAll();

            List<ProjectTaskDTO> taskDTOs = new List<ProjectTaskDTO>();

            for(int i=0; i< projectTask.Count; i++)
            {
                taskDTOs.Add(new ProjectTaskDTO { 
                 Id= projectTask[i].Id,
                 Priority= projectTask[i].Priority,
                 Topic= projectTask[i].Topic,
                 Type = projectTask[i].Type,
                 projectDTO = new ProjectDTO {Id= projectTask[i].project.Id, Name= projectTask[i].project.Name},
                 userDTO = new UserDTO { Id= projectTask[i].user.Id, Name= projectTask[i].user.Name, SerName= projectTask[i].user.SerName},
                 projectId = projectTask[i].ProjectId,
                 userId= projectTask[i].UserId
                });
            }

            return taskDTOs;

        }

        public ProjectTaskDTO GetById(int id)
        {
            var projectTask = db.projectTasks.GetById(id);
            var project = db.projects.GetById(projectTask.project.Id);
            var user = db.users.GetById(projectTask.user.Id);

            var taskDTO = new ProjectTaskDTO
            {
                 Priority = projectTask.Priority,
                  Topic= projectTask.Topic,
                   Type= projectTask.Type,
                    projectDTO = new ProjectDTO
                    {
                         Id= project.Id,
                          Name= project.Name
                    },
                    userDTO = new UserDTO
                    {
                         Id= user.Id,
                          Name = user.Name,
                          SerName=user.SerName
                    }
        };

            return taskDTO;
        }

        public void Update(ProjectTaskDTO t)
        {
            var projectTask = db.projects.GetById(t.Id);

            //projectTask.Name = t.Name;
            db.Save();
        }
    }
}
