using Microsoft.EntityFrameworkCore;
using PersonalAccounts2._0.DataAccess;
using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.Repository.Implementation
{
    public class AccountRepository : DataContextRepository<AccountModel>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {
            
        }

        public virtual async Task<List<AccountModel>> GetAllAsync() => await _context.Accounts
            .Include(a => a.AccountResidents)
            .ThenInclude(ar => ar.Resident)
            .ToListAsync();
    }
}
