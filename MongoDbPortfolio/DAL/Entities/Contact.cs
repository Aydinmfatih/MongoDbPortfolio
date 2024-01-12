using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
