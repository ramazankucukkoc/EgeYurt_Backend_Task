using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace EgeYurt_Backend_Task.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        protected TContext Context;
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async  Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public  IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);

            return (IList<TEntity>)queryable;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

    }
}
