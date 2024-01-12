using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPortfolio.DAL.Entities
{
    public class TimeZone
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TimeZoneId { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
    }
}
