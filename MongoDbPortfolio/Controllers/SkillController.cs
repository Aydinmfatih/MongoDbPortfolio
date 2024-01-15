using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMongoCollection<Skill> _skillColleciton;

        public SkillController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillColleciton = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _skillColleciton.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            await _skillColleciton.InsertOneAsync(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSkill(string id)
        {
            var value = await _skillColleciton.DeleteOneAsync(x => x.SkillId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSkill(string id)
        {
            var value = await _skillColleciton.Find(x => x.SkillId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            var value = await _skillColleciton.FindOneAndReplaceAsync(x => x.SkillId == skill.SkillId, skill);
            return RedirectToAction("Index");
        }
    }
}
