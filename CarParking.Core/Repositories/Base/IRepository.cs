using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarParking.Core.Entities.Base;
using CarParking.Core.Specifications.Base;

namespace CarParking.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeString = null,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            List<Expression<Func<T, object>>> includes,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
