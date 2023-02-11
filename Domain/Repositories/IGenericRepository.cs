using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        IQueryable<T> Query();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
