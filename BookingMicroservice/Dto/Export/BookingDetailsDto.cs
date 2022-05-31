using BookingMicroservice.Enums;

namespace BookingMicroservice.Dto.Export
{
    public class BookingDetailsDto
    {
        public int Id { get; set; }
        public string? BranchAddress { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public string? EmployeeName { get; set; }
        public int TotalDuration { get; set; }
        public decimal TotalCost { get; set; }
        public List<ServiceReadDto>? Services { get; set; }
    }
}
