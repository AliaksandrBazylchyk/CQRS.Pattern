using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CQRS.Pattern.Infrastructure.Base
{
    public interface IRepository<T> : IQueryable<T>
        where T : BaseEntity
    {
        IMongoCollection<T> Collection { get; }
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}