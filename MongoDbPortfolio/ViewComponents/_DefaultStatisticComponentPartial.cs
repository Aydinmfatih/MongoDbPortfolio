using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
