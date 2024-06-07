using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.Repository
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object?>>[] include);
        Task<List<T>> ListAccountsAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(int Id);
    }
}
