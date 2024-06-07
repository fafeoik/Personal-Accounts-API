using Microsoft.EntityFrameworkCore;
using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.Repository.Implementation
{
    public class Repository<T, TContext> : IRepository<T>
    where T : class
    where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repository(TContext dbContext) => _context = dbContext;

        public virtual Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate,params Expression<Func<T, object?>>[] include)
        {
            var query = _context.Set<T>().Where(predicate);

            query = include.Aggregate(query, (current, inc) => current.Include(inc));

            return query.ToListAsync();
        }

        public async Task<List<T>> ListAccountsAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>()
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync();

        public async Task<T?> GetByIdAsync(int Id) => await _context.Set<T>().FindAsync(Id);

        public async Task<int> AddAsync(T entity)
        {
            var addedEntity = await _context.Set<T>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
            return Convert.ToInt32(addedEntity.Property("Id").CurrentValue);
        }

        public virtual Task Update(T entity)
        {
            _ = _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _ = _context.Set<T>().Remove(entity);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
