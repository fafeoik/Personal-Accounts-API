using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    where T : class
    {
        Task<int> AddAsync(T entity);
        Task Update(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
