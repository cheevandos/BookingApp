using BookingMicroservice.Enums;

namespace BookingMicroservice.Dto.Export
{
    public class EmployeeBookingDetailsDto
    {
        public int Id { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerPhone { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalDuration { get; set; }
        public decimal TotalCost { get; set; }
        public List<ServiceReadDto>? Services { get; set; }
    }
}
