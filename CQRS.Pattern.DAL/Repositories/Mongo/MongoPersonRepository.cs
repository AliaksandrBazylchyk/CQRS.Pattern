using CQRS.Pattern.DAL.Base;
using CQRS.Pattern.DAL.Entities;

namespace CQRS.Pattern.DAL.Repositories.Mongo
{
    public class MongoPersonRepository : MongoRepository<Person>, IMongoPersonRepository
    {
    }
}