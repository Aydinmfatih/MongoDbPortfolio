using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultContactComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public _DefaultContactComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
