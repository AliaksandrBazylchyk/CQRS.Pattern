namespace CQRS.Pattern.Configurations
{
    public class ConnectionOptions
    {
        public static string SectionName = "DbConnection";
        public string PostgresConnectionString { get; set; }
        public string MongoDbConnectionClient { get; set; }
        public string MongoDbConnectionDatabase { get; set; }
    }
}
