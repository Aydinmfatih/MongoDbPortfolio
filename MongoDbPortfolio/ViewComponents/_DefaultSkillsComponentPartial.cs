using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultSkillsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
