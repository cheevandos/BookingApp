using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Repos.Interfaces
{
    public interface IBranchesRepository : IRepositoryBase
    {
        Task<List<Branch>?> GetBranchesByCompanyId(int companyId);
        Task<Branch?> GetBranch(int branchId);
        Task CreateBranch(Branch newBranch);
    }
}
