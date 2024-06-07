using System.ComponentModel.DataAnnotations;

namespace PersonalAccounts2._0.DTO
{
    public class ResidentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
