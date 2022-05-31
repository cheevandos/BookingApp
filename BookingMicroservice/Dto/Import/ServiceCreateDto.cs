using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Dto.Import
{
    public class ServiceCreateDto
    {
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}