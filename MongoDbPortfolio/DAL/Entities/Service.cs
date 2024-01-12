using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceId { get; set; }
        public string ServideTitle { get; set; }
        public decimal ServicePrice { get; set; }
        public string Description { get; set; }
    }
}
