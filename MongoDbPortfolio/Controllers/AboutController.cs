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
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutCollection.Find(x=>true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public  IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(About about)
        {
            await _aboutCollection.InsertOneAsync(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var value = await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutCollection.Find(x=>x.AboutId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About about)
        {
            var value = await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == about.AboutId, about);
            return RedirectToAction("Index");
        }

    }
}
