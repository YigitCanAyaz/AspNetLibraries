using ErrorHandling.Web.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Web.Controllers
{
    [CustomHandleExceptionFilter(ErrorPage = "CustomError2")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Error in database");

            return View();
        }


        public IActionResult CustomError2()
        {
            return View();
        }
    }
}
