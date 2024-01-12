using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string ImageUrl { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
    }
}
