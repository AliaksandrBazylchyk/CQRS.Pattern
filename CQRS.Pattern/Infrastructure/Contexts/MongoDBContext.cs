using System;
using System.Collections.Generic;
using CQRS.Pattern.Infrastructure.Configurations;
using CQRS.Pattern.Models.Persons;
using MongoDB.Driver;

namespace CQRS.Pattern.Infrastructure.Contexts
{
    public class MongoDBContext
    {
        private readonly IMongoCollection<Person> _persons;

        public MongoDBContext(ConnectionOptions options)
        {
            var client = new MongoClient(options.MongoDbConnectionClient);
            var database = client.GetDatabase(options.MongoDbConnectionDatabase);
            _persons = database.GetCollection<Person>("Persons");
        }

        public Person Create(Person submission)
        {
            _persons.InsertOne(submission);
            return submission;
        }

        public IEnumerable<Person> Read() =>
            _persons.Find(sub => true).ToList();

        public Person Find(Guid id) =>
            _persons.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Person person) =>
            _persons.ReplaceOne(sub => sub.Id == person.Id, person);

        public void Delete(Guid id) =>
            _persons.DeleteOne(sub => sub.Id == id);
    }
}