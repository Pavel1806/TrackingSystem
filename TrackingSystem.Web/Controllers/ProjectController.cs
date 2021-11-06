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

        public IActionResult FormAllTasks()
        {
            var map = new MapperConfiguration(x => x.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            var modelProject = map.Map<IEnumerable<ProjectDTO>, IEnumerable<ProjectViewModel>>(_projectServices.GetAll());

            return View(modelProject);
        }

        public IActionResult GetAllTasks(int id)
        {

            return RedirectToAction("AllTasks", "Project", new { id });
        }
        public IActionResult AllTasks(int id)
        {
            var modelProject = _projectServices.GetById(id);

            return View(modelProject);
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
