using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
