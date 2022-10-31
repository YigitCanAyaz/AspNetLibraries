using Logging.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logging.Web.Controllers
{
    public class HomeController : Controller
    {
        // First way to do it
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        // second way to do it
        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var _logger = _loggerFactory.CreateLogger("HomeClass");

            _logger.LogTrace("Entered to index page");
            _logger.LogDebug("Entered to index page");
            _logger.LogInformation("Entered to index page");
            _logger.LogWarning("Entered to index page");
            _logger.LogError("Entered to index page");
            _logger.LogCritical("Entered to index page");

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