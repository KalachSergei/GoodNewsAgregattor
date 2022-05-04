using Microsoft.EntityFrameworkCore;
using MVCNewsAggregator.Core.Interfaces.Data;
using MVCNewsAgreggator.Data;
using MVCNewsAgreggator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly NewsAggregatorContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(NewsAggregatorContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual async Task Add(T obj)
        {
            await DbSet.AddAsync(obj);
        }

        public virtual async Task AddRange(IEnumerable<T> obj)
        {
            await DbSet.AddRangeAsync(obj);
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual async Task<T> GetByIdWithIncludes(Guid id, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Any())
            {
                return await includes.Aggregate(DbSet.Where(entity => entity.Id.Equals(id)),
                    (current, include) => current.Include(include)).FirstOrDefaultAsync();
            }

            return await GetById(id);
        }

        public virtual IQueryable<T> Get()
        {
            return DbSet;
        }

        public virtual async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes)
        {
            var result = DbSet.Where(predicate);
            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }

            return result;
        }

        public virtual async Task Update(T obj)
        {
            DbSet.Update(obj);
        }

        public virtual async Task PatchAsync(Guid id, List<PatchModel> patchDtos)
        {
            var model = await DbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            var nameValuePairProperties = patchDtos
                .ToDictionary(a => a.PropertyName, a => a.PropertyValue);

            var dbEntityEntry = Db.Entry(model);
            dbEntityEntry.CurrentValues.SetValues(nameValuePairProperties);
            dbEntityEntry.State = EntityState.Modified;
        }


        public virtual async Task RemoveRange(Expression<Func<T, bool>> predicate)
        {
            var entities = DbSet.Where(predicate);

            DbSet.RemoveRange(entities);
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
