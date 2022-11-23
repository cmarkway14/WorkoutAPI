namespace Models
{
    public class AppConfig : IAppConfig
    {
        public string MongoClientConnection { get; set; }
        public string MongoDatabaseTable { get; set; }
    }
}
