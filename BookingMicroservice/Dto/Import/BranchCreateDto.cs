using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Dto.Import
{
    public class BranchCreateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
