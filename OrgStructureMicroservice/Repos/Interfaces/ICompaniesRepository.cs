using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Repos.Interfaces
{
    public interface ICompaniesRepository : IRepositoryBase
    {
        Task<List<Company>?> GetAllCompanies();
        Task<Company?> GetCompanyById(int id);
    }
}
