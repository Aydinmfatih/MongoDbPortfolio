using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.Controllers
{
    public class AdminUILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
