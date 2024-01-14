using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public AboutController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName)
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutCollection.Find(x=>true).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            var values = await _aboutCollection.
            return View();
        }
    }
}
