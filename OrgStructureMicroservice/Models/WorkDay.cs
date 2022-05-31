using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class WorkDay
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}