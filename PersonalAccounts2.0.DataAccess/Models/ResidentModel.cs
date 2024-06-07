using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounts.Core.Models;

namespace PersonalAccounts2._0.DataAccess.Models
{
    [Table("Residents")]
    public class ResidentModel : IEntity
    {
        public ResidentModel()
        {
            AccountResidents = new List<AccountResidentModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<AccountResidentModel> AccountResidents { get; set; }
    }
}
