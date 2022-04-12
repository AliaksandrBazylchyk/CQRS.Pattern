using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CQRS.Pattern.DAL.Base
{
    public abstract class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : BaseEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        protected MongoRepository()
        {
            var database = new MongoClient("mongodb://localhost:27017").GetDatabase("cqrs");
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return documentType.Name + 's';
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public IEnumerable<TDocument> GetAll()
        {
            return _collection.AsQueryable().AsEnumerable();
        }


        public virtual Task<TDocument> FindByIdAsync(Guid id)
        {
            return _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }
    }
}