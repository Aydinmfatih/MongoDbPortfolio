using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly IMongoCollection<Education> _educationCollection;

        public EducationController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _educationCollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values = await _educationCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation(Education education)
        {
            await _educationCollection.InsertOneAsync(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEducation(string id)
        {
            var value = await _educationCollection.DeleteOneAsync(x => x.EducationId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEducation(string id)
        {
            var value = await _educationCollection.Find(x => x.EducationId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(Education education)
        {
            var value = await _educationCollection.FindOneAndReplaceAsync(x => x.EducationId == education.EducationId, education);
            return RedirectToAction("Index");
        }
    }
}
