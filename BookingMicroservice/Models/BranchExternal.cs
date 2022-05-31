using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
{
    public class BranchExternal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string? Address { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
