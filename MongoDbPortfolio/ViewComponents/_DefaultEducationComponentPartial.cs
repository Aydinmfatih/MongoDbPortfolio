using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultEducationComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Education> _educationCollection;

        public _DefaultEducationComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _educationCollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _educationCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
