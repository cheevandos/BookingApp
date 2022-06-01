using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface IExternalImportRepository : IRepositoryBase
    {
        Task CreateCompanyExt(CompanyExternal companyExternal);
        Task CreateBranchExt(BranchExternal branchExternal);
        Task CreateServiceExt(ServiceExternal serviceExternal);
        Task CreateEmployeeExt(EmployeeExternal employeeExternal);
    }
}
