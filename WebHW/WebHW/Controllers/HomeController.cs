using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WebHW.Models;
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

        public IActionResult DataBase(IProjectService projectService, IEmployeeService employeeService)
        {
            ViewData["employees"] = employeeService.ListEmployees().ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
