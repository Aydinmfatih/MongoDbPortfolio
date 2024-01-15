using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Experience
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExperienceId { get; set; }
        public string Title { get; set; }
        public string StartYear { get; set; }
        public string CompanyName { get; set; }
    }
}
