using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Education
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EducationId { get; set; }
        public string Title { get; set; }
        public string StartYear { get; set; }
        public string EducationName { get; set; }

    }
}
