using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbPortfolio.DAL.Entities;
using MongoDbPortfolio.DAL.Settings;

namespace MongoDbPortfolio.ViewComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;

        public _DefaultTestimonialComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
    }
}
