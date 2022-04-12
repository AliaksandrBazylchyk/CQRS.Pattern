using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Pattern.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Pattern.DAL.Base
{
    public class NpgsqlRepository<T> : INpgsqlRepository<T>
        where T : BaseEntity
    {
        protected readonly NpgsqlContext Context;
        protected readonly DbSet<T> DbSet;

        protected NpgsqlRepository(NpgsqlContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(entity => entity.Id == id);

            DbSet.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var result = DbSet.AsQueryable().AsEnumerable();

            return Task.FromResult(result);
        }
    }
}