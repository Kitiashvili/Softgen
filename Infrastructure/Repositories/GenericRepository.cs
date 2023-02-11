using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Delete(Guid id)
        {
            var entity = GetByIdAsync(id);
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) >= 0 ? true : false;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }
        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return (await _context.SaveChangesAsync()) >= 0 ? true : false;
        }
        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() =>
            _context.Set<T>().Where(predicate));
        }
    }
}
