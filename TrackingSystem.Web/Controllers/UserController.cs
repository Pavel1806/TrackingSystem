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
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IServices<UserDTO> _userServices;

        public UserController(ILogger<HomeController> logger, IServices<UserDTO> userTask)
        {
            _logger = logger;
            _userServices = userTask;
        }

        public IActionResult Index()
        {
            var map = new MapperConfiguration(x => x.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var modelUser = map.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(_userServices.GetAll());
            
            return View(modelUser);
        }

        public IActionResult AddingNewUser(string name, string sername)
        {


             _userServices.Create(
                new UserDTO { 
                 Name= name,
                 SerName= sername
                });

            return RedirectToAction("Index", "User");




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
