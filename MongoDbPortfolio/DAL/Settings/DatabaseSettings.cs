namespace MongoDbPortfolio.DAL.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string EducationCollectionName { get; set; }
        public string ExperienceCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SkillCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string TimeZoneCollectionName { get; set; }
    }
}
