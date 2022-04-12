using CQRS.Pattern.DAL.Base;
using CQRS.Pattern.DAL.Entities;

namespace CQRS.Pattern.DAL.Repositories
{
    public interface IMongoPersonRepository : IMongoRepository<Person>
    {
    }
}