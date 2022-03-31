using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQRS.Pattern.Infrastructure.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CQRS.Pattern.Infrastructure.Repositories
{
    public abstract class MongoDbRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected internal IMongoCollection<T> collection;
        public IMongoCollection<T> Collection => collection;

        public async Task<T> GetByIdAsync(Guid id)
            => await collection.Find(new BsonDocument("_id", id)).FirstOrDefaultAsync<T>();

        public async Task<T> AddAsync(T entity)
        {
            await collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(Guid id) => await collection.DeleteOneAsync(new BsonDocument("_id", id));

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = collection.AsQueryable().ToEnumerable();

            return result;
        }

        #region IQueryable<T>

        public virtual IEnumerator<T> GetEnumerator() => collection.AsQueryable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => collection.AsQueryable().GetEnumerator();
        public virtual Type ElementType => collection.AsQueryable().ElementType;
        public virtual Expression Expression => collection.AsQueryable().Expression;
        public virtual IQueryProvider Provider => collection.AsQueryable().Provider;

        #endregion IQueryable<T>
    }
}