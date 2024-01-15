using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Settings;
using TimeZone = MongoDbPortfolio.DAL.Entities.TimeZone;
namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultTimeZoneComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<TimeZone> _timezoneColleciton;

        public _DefaultTimeZoneComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _timezoneColleciton = database.GetCollection<TimeZone>(_databaseSettings.TimeZoneCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _timezoneColleciton.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
