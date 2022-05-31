using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Repos.Interfaces
{
    public interface IServicesRepository : IRepositoryBase
    {
        Task<List<Service>?> GetByCompanyId(int companyId);
        Task<List<Service>?> GetByEmployeeId(int employeeId);
        Task<Service?> GetById(int serviceId);
        Task CreateService(Service newService);
    }
}
