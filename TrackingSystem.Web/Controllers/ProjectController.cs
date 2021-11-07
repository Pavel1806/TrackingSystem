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
    public class ProjectController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IServices<ProjectDTO> _projectServices;

        public ProjectController(ILogger<HomeController> logger, IServices<ProjectDTO> projectTask)
        {
            _logger = logger;
            _projectServices = projectTask;
        }

        public IActionResult Index()
        {
            var map = new MapperConfiguration(x => x.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            var modelProject = map.Map<IEnumerable<ProjectDTO>, IEnumerable<ProjectViewModel>>(_projectServices.GetAll());
           
            return View(modelProject);
        }

        public IActionResult AddingNewProject(string name)
        {
            _projectServices.Create(
                new ProjectDTO { 
                 Name= name
                });

            return RedirectToAction("Index", "Project");
        }

        public IActionResult AllTasks(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Error", "Home");

            }
            else
            {
                var projectDTO = _projectServices.GetById(id);
                var listTasks = new List<ProjectTaskViewModel>();
                foreach (var item in projectDTO.Tasks)
                {

                    listTasks.Add(new ProjectTaskViewModel
                    {
                        Id = item.Id,
                        Priority = item.Priority,
                        Topic = item.Topic,
                        Type = item.Type,
                        User = new UserViewModel
                        {
                            Id = item.userDTO.Id,
                            Name = item.userDTO.Name,
                            SerName = item.userDTO.SerName,
                        }
                    });
                }
                ProjectViewModel projectViewModel = new ProjectViewModel { Id = projectDTO.Id, Name = projectDTO.Name, Tasks = listTasks };

                return View(projectViewModel);
            }
            
            
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
