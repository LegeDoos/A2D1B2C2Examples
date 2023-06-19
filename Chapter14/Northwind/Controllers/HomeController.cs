using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.Shared;
using System.Diagnostics;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindDataContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindDataContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogError("This is a serious error (not!)");
            _logger.LogWarning("Warning 1... 2...");
            _logger.LogCritical("Einde oefening!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}