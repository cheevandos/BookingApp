namespace OrgStructureMicroservice.Dto.Import
{
    public class ServiceCreateDto
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}
