using System.ComponentModel.DataAnnotations;

namespace OrgStructureMicroservice.Models
{
    public class TimeUnit
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public Guid WorkDayId { get; set; }
        public WorkDay? WorkDay { get; set; }
    }
}