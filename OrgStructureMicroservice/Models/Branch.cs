using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class Branch
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}