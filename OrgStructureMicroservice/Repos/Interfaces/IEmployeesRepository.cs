using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Repos.Interfaces
{
    public interface IEmployeesRepository : IRepositoryBase
    {
        Task<List<Employee>?> GetEmployeesByCompanyId(int companyId);
        Task<List<Employee>?> GetEmployeesByBranchId(int branchId);
        Task<Employee?> GetEmployeeById(int employeeId);
        Task CreateEmployee(Employee newEmployee);
    }
}
