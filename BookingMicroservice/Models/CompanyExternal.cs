using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
{
    public class CompanyExternal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string? Name { get; set; }
        
        public ICollection<Booking>? Bookings { get; set; }
    }
}
