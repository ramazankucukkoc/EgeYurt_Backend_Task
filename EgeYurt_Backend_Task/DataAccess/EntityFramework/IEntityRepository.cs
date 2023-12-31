﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EgeYurt_Backend_Task.DataAccess.EntityFramework
{
    public interface IEntityRepository<T>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        IQueryable<T> Query();
    }
}
