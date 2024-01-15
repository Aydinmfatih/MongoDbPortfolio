using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultServicesComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public _DefaultServicesComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
