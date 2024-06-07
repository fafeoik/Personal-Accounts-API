using PersonalAccounts.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.DataAccess.Models
{
    [Table("Accounts")]
    public class AccountModel :IEntity
    {
        public AccountModel()
        {
            AccountResidents = new List<AccountResidentModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Column(TypeName = "REAL")]
        public decimal RoomArea { get; set; }
        public List<AccountResidentModel> AccountResidents { get; set; }
    }
}
