using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Database;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Repos
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly OrgStructDbContext _context;

        public ServicesRepository(OrgStructDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateService(Service newService)
        {
            if (_context.Services != null)
            {
                await _context.Services.AddAsync(newService);
            }
        }

        public async Task<List<Service>?> GetByCompanyId(int companyId)
        {
            if (_context.Services != null)
            {
                return await _context.Services
                    .Where(service => service.CompanyId == companyId)
                    .ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Service>?> GetByEmployeeId(int employeeId)
        {
            if (_context.Services != null && _context.Employees != null)
            {
                try
                {
                    Employee? employee = await _context.Employees
                        .Include(empl => empl.Services)
                        .FirstOrDefaultAsync(empl => empl.Id == employeeId);

                    return employee?.Services?.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public Task<Service?> GetById(int serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
