using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;

        public TestimonialController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {
            await _testimonialCollection.InsertOneAsync(testimonial);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            var value = await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            var value = await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == testimonial.TestimonialId, testimonial);
            return RedirectToAction("Index");
        }
    }
}
