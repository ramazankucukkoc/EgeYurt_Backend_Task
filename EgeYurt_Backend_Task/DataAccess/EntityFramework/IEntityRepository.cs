using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EgeYurt_Backend_Task.DataAccess.EntityFramework
{
    public interface IEntityRepository<T>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IList<T> GetList(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        IQueryable<T> Query();
    }
}
