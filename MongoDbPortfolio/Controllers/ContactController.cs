using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _contactCollection.InsertOneAsync(contact);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var value = await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            var value = await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == contact.ContactId, contact);
            return RedirectToAction("Index");
        }
    }
}
