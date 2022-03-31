using System;
using CQRS.Pattern.Infrastructure.Configurations;
using MongoDB.Driver;

namespace CQRS.Pattern.Infrastructure.Contexts
{
    public class MongoDBContext
    {
        public readonly IMongoClient Client;
        public readonly IMongoDatabase MongoDatabase;

        public MongoDBContext(ConnectionOptions options, Action initConventions = null)
        {
            Client = new MongoClient(options.MongoDbConnectionClient);
            MongoDatabase = Client.GetDatabase(options.MongoDbConnectionDatabase);
        }
    }
}