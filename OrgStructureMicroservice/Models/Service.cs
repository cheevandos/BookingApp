using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class Service
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int TimeUnits { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}