using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Dto.Import
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public IEnumerable<int>? Services { get; set; }
    }
}
