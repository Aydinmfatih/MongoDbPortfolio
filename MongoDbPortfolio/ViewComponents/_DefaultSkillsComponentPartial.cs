using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultSkillsComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Skill> _skillColleciton;

        public _DefaultSkillsComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillColleciton = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _skillColleciton.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
