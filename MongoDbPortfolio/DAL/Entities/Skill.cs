using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbPortfolio.DAL.Entities
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SkillId{ get; set; }
        public string Title { get; set; }
        public string SkillTitle { get; set; }
        public int Percent { get; set; }
        public string BarColor { get; set; }
    }
}
