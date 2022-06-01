using BookingMicroservice.Enums;

namespace BookingMicroservice.Dto.Export
{
    public class EmployeeBookingShortInfoDto
    {
        public int Id { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalCost { get; set; }
    }
}
