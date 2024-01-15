using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Experience> _experienceCollection;

        public _DefaultExperienceComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _experienceCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
