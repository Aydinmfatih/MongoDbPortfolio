using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
