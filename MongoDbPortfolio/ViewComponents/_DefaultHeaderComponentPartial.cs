﻿using Microsoft.AspNetCore.Mvc;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
