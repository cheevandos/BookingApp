using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<Service>? Services { get; set; }
    }
}
