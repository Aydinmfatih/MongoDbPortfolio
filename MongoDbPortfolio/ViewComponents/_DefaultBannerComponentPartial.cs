using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultBannerComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public _DefaultBannerComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
