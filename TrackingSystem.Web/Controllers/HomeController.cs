using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystem.Web.Models;
using TrackingSystem.BLL.Interfaces;
using TrackingSystem.BLL.Models;
using AutoMapper;

namespace TrackingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IServices<ProjectTaskDTO> _projectTaskServices;
        private readonly IServices<ProjectDTO> _projectServices;
        private readonly IServices<UserDTO> _userServices;

        public HomeController(ILogger<HomeController> logger, IServices<ProjectTaskDTO> projectTask, IServices<ProjectDTO> project, IServices<UserDTO> user)
        {
            _logger = logger;
            _projectTaskServices = projectTask;
            _projectServices = project;
            _userServices = user;
        }

        public IActionResult Index()
        {

            var projectTask = _projectTaskServices.GetAll();
            var project = _projectServices.GetAll();
            var user = _userServices.GetAll();

            var projectVW = new List<ProjectViewModel>();
            foreach(var item in project)
            {
                projectVW.Add(new ProjectViewModel {  Id= item.Id, Name=item.Name});
            }
            var userVW = new List<UserViewModel>();
            foreach (var item in user)
            {
                userVW.Add(new UserViewModel { Id = item.Id, Name = item.Name, SerName=item.SerName });
            }
            List<ProjectTaskViewModel> taskDTOs = new List<ProjectTaskViewModel>();

            for (int i = 0; i < projectTask.Count(); i++)
            {
                taskDTOs.Add(new ProjectTaskViewModel
                {
                    Id = projectTask[i].Id,
                    Priority = projectTask[i].Priority,
                    Topic = projectTask[i].Topic,
                    Type = projectTask[i].Type,
                    Project = new ProjectViewModel { Id = projectTask[i].projectDTO.Id, Name = projectTask[i].projectDTO.Name },
                    User = new UserViewModel { Id = projectTask[i].userDTO.Id, Name = projectTask[i].userDTO.Name, SerName = projectTask[i].userDTO.SerName },
                    projectViewModels = projectVW,
                    userViewModels= userVW,
                    projectId = projectTask[i].projectId,
                    userId = projectTask[i].userId
                }) ;
            }
            return View(taskDTOs);
        }

        public IActionResult AddingNewTask(int projectId, int userId, string priority, string topic, string type)
        {
            _projectTaskServices.Create(
                new ProjectTaskDTO { Priority= priority ,  projectId= projectId, userId= userId, Topic= topic, Type= type }
                );

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Delete(int id)
        {
            _projectTaskServices.Delete(id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id, string priority, string topic, string type, string nameproject, string sername, int userId, int projectId )
        {
            var project = _projectServices.GetAll();
            var user = _userServices.GetAll();

            var projectVW = new List<ProjectViewModel>();
            foreach (var item in project)
            {
                if(item.Id != projectId)
                {
                    projectVW.Add(new ProjectViewModel { Id = item.Id, Name = item.Name });
                }
                
            }
            var userVW = new List<UserViewModel>();
            foreach (var item in user)
            {
                if (item.Id != userId)
                {
                    userVW.Add(new UserViewModel { Id = item.Id, Name = item.Name, SerName = item.SerName });
                }
                    
            }

            ProjectTaskViewModel projectTaskView = new ProjectTaskViewModel
            {
                Id= id,
                Priority = priority,
                Topic = topic,
                Type = type,
                Project = new ProjectViewModel { Name = nameproject },
                User = new UserViewModel { SerName = sername },
                projectViewModels = projectVW,
                userViewModels = userVW
            };


            return View(projectTaskView);
        }
        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
