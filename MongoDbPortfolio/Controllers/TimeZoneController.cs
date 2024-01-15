using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;
using TimeZone = MongoDbPortfolio.DAL.Entities.TimeZone;

namespace MongoDbPortfolio.Controllers
{
    public class TimeZoneController : Controller
    {
        private readonly IMongoCollection<TimeZone> _timezoneColleciton;

        public TimeZoneController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _timezoneColleciton = database.GetCollection<TimeZone>(_databaseSettings.TimeZoneCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _timezoneColleciton.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTimeZone()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeZone(TimeZone timeZone)
        {
            await _timezoneColleciton.InsertOneAsync(timeZone);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTimeZone(string id)
        {
            var value = await _timezoneColleciton.DeleteOneAsync(x => x.TimeZoneId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTimeZone(string id)
        {
            var value = await _timezoneColleciton.Find(x => x.TimeZoneId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTimeZone(TimeZone timeZone)
        {
            var value = await _timezoneColleciton.FindOneAndReplaceAsync(x => x.TimeZoneId == timeZone.TimeZoneId, timeZone);
            return RedirectToAction("Index");
        }
    }
}
