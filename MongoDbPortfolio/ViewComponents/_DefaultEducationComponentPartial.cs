using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultEducationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
