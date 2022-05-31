using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
{
    public class ServiceExternal
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
