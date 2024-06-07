using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.Repository
{
    public interface IAccountRepository : IRepository<AccountModel>
    {
        Task<List<AccountModel>> GetAllAsync();
    }
}
