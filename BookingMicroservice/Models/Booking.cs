using BookingMicroservice.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookingMicroservice.Models
{
    public class Booking
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int TotalDuration { get; set; }
        [Required]
        public decimal TotalCost { get; set; }

        public int UserId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerPhone { get; set; }

        [Required]
        public int CompanyExternalId { get; set; }
        public CompanyExternal? CompanyExternal { get; set; }

        [Required]
        public int BranchExternalId { get; set; }
        public BranchExternal? BranchExternal { get; set; }
        
        [Required]
        public int EmployeeExternalId { get; set; }
        public EmployeeExternal? EmployeeExternal { get; set; }

        public ICollection<ServiceExternal>? Services { get; set; }
    }
}
