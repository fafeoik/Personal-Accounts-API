using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts.Core.Models
{
    [Table("AccountsResidents")]
    public class AccountResidentModel : IEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public AccountModel Account { get; set; }
        public int ResidentId { get; set; }
        public ResidentModel Resident { get; set; }
    }
}
