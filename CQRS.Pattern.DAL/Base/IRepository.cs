using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Pattern.DAL.Base
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}