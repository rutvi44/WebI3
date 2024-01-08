using InClass3RM.Controllers;
using InClass3RM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InClass3RM.Controllers
{
    public class HomeController : AbstractBaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                UserTrackingMessage = GenerateUserTrackingMessage("Home")
            };
            return View(homeViewModel);
        }

        public IActionResult other()
        {
            return View();
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