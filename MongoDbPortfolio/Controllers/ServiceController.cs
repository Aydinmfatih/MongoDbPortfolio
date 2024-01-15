using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;
using Newtonsoft.Json;

namespace MongoDbPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public ServiceController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ServiceList()
        {
            var values = await _serviceCollection.Find(x => true).ToListAsync();
            var jsonServices = JsonConvert.SerializeObject(values);
            return Json(jsonServices);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            await _serviceCollection.InsertOneAsync(service);
            var values = JsonConvert.SerializeObject(service);
            return Json(values);

        }

        public async Task<IActionResult> GetService(string serviceId)
        {
            var values = await _serviceCollection.Find(x => x.ServiceId == serviceId).FirstOrDefaultAsync();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);

        }
        public async Task<IActionResult> DeleteService(string id)
        {
            var values = await _serviceCollection.DeleteOneAsync(x => x.ServiceId == id);
            return NoContent();

        }
        public async Task<IActionResult> UpdateService(Service service)
        {
            var values = await _serviceCollection.FindOneAndReplaceAsync(x => x.ServiceId == service.ServiceId, service);
            return NoContent();

        }

    }
}
