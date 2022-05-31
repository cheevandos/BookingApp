using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
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
        public int EmployeeExternalId { get; set; }
        public EmployeeExternal? EmployeeExternal { get; set; }
    }
}
