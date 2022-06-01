using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface IExternalUpdateRepository : IRepositoryBase
    {
        Task UpdateCompanyExt(CompanyExternal companyExternal);
        Task UpdateBranchExt(BranchExternal branchExternal);
        Task UpdateServiceExt(ServiceExternal serviceExternal);
        Task UpdateEmployeeExt(EmployeeExternal employeeExternal);
    }
}
