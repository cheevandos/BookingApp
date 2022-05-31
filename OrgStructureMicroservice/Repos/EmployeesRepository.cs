using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Database;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Repos
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly OrgStructDbContext _context;

        public EmployeesRepository(OrgStructDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateEmployee(Employee newEmployee)
        {
            if (_context.Employees != null)
            {
                await _context.Employees.AddAsync(newEmployee);
            }
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            if (_context.Employees != null)
            {
                return await _context.Employees
                    .FirstOrDefaultAsync(empl => empl.Id == employeeId);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Employee>?> GetEmployeesByBranchId(int branchId)
        {
            if (_context.Employees != null)
            {
                return await _context.Employees
                    .Where(empl => empl.BranchId == branchId)
                    .ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public Task<List<Employee>?> GetEmployeesByCompanyId(int companyId)
        {
            if (_context.Employees != null && _context.Branches != null)
            {
                IQueryable<ICollection<Employee>?>? branches = _context.Branches
                    .Include(branch => branch.Employees)
                    .Where(comp => comp.CompanyId == companyId)
                    .Select(branch => branch.Employees);

                List<Employee>? employees = new();

                foreach (ICollection<Employee>? branchEmployees in branches)
                {
                    if (branchEmployees != null)
                    {
                        employees.AddRange(branchEmployees);
                    }
                }

                return employees.Any() ? 
                    Task.FromResult<List<Employee>?>(employees) :
                    Task.FromResult<List<Employee>?>(null);
            }
            else
            {
                return Task.FromResult<List<Employee>?>(null);
            }
        }
    }
}
