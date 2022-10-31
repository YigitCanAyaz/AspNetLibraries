using ErrorHandling.Web.Filter;
using ErrorHandling.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomHandleExceptionFilter(ErrorPage = "CustomError1")]
        public IActionResult Index()
        {
            int value1 = 5;
            int value2 = 0;

            int result = value1 / value2;

            return View();
        }

        [CustomHandleExceptionFilter(ErrorPage = "CustomError2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous] // to allow non registered user
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;

            return View();
        }

        public IActionResult CustomError1()
        {
            return View();
        }
    }
}