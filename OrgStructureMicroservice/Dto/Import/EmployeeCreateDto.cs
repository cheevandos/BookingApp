namespace OrgStructureMicroservice.Dto.Import
{
    public class EmployeeCreateDto
    {
        public int BranchId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
    }
}
