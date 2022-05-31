using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
{
    public class EmployeeExternal
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Position { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<TimeUnit>? TimeUnits { get; set; }
    }
}