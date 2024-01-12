using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
