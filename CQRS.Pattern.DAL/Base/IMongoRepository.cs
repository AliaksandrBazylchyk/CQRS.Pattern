using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CQRS.Pattern.DAL.Base
{
    public interface IMongoRepository<TDocument> where TDocument : BaseEntity
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TDocument> GetAll();
        Task<TDocument> FindByIdAsync(Guid id);

        Task InsertOneAsync(TDocument document);

        Task DeleteByIdAsync(Guid id);
    }
}