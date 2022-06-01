using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Dto.Import
{
    public class EmployeeCreateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Position { get; set; }
    }
}
