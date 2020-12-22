using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WebHW.Models;
using WebHW.Repositories;
using WebHW.Services;

namespace WebHW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["UserGuidProvider"] = Environment.OSVersion;
            ViewData["ViewCount"] = GlobalVariables.ViewCount;
            return View();
        }

        //public string EmployeeProjects([FromServices] ProjectRepository employeeService, int id)
        //{
        //    var t = employeeService.Find(id);
        //    return View(t);
        //}

        public IActionResult EmployeeProjects([FromServices] IEmployeeService employeeService, int id)
        {
            var t = employeeService.Find(id);
            return View(t);
        }

        public IActionResult DataBase([FromServices] IEmployeeService employeeService, [FromServices] IProjectService projectService)
        {
            ViewBag.Employees = employeeService.ListEmployees().ToList();
            ViewBag.Projects = projectService.ListProjects().ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
