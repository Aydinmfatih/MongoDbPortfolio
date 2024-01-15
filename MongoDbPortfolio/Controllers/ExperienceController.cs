using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IMongoCollection<Experience> _experienceCollection;

        public ExperienceController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values = await _experienceCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience(Experience experience)
        {
            await _experienceCollection.InsertOneAsync(experience);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteExperience(string id)
        {
            var value = await _experienceCollection.DeleteOneAsync(x => x.ExperienceId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateExperience(string id)
        {
            var value = await _experienceCollection.Find(x => x.ExperienceId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExperience(Experience experience)
        {
            var value = await _experienceCollection.FindOneAndReplaceAsync(x => x.ExperienceId == experience.ExperienceId, experience);
            return RedirectToAction("Index");
        }
    }
}
