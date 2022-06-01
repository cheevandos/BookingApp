using BookingMicroservice.Enums;

namespace BookingMicroservice.Dto.Export
{
    public class CustomerBookingShortInfoDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchAddress { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalCost { get; set; }
    }
}