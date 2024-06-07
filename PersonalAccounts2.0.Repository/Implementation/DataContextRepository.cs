using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounts2._0.DataAccess;

namespace PersonalAccounts2._0.Repository.Implementation
{
    public class DataContextRepository<T> : Repository<T, DataContext>
    where T : class
    {
        public DataContextRepository(DataContext context) : base(context)
        {
        }
    }
}
