using BookingMicroservice.Database;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingMicroservice.Repos
{
    public class ExternalRepository : IExternalImportRepository, IExternalUpdateRepository
    {
        private readonly BookingDbContext _context;

        public ExternalRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateBranchExt(BranchExternal branchExternal)
        {
            if (_context.Branches != null)
            {
                await _context.Branches.AddAsync(branchExternal);
            }
        }

        public async Task CreateCompanyExt(CompanyExternal companyExternal)
        {
            if (_context.Companies != null)
            {
                await _context.Companies.AddAsync(companyExternal);
            }
        }

        public async Task CreateEmployeeExt(EmployeeExternal employeeExternal)
        {
            if (_context.Employees != null)
            {
                await _context.Employees.AddAsync(employeeExternal);
            }
        }

        public async Task CreateServiceExt(ServiceExternal serviceExternal)
        {
            if (_context.Services != null)
            {
                await _context.Services.AddAsync(serviceExternal);
            }
        }

        public async Task UpdateBranchExt(BranchExternal branchExternal)
        {
            if (_context.Branches != null)
            {
                BranchExternal? existingBranch = await _context.Branches
                    .FirstOrDefaultAsync(branch => branch.ExternalId == branchExternal.ExternalId);

                if (existingBranch != null)
                {
                    _context.Branches.Update(branchExternal);
                }
            }
        }

        public async Task UpdateCompanyExt(CompanyExternal companyExternal)
        {
            if (_context.Companies != null)
            {
                CompanyExternal? existingCompany = await _context.Companies
                    .FirstOrDefaultAsync(company => company.ExternalId == companyExternal.ExternalId);

                if (existingCompany != null)
                {
                    _context.Companies.Update(companyExternal);
                }
            }
        }

        public async Task UpdateEmployeeExt(EmployeeExternal employeeExternal)
        {
            if (_context.Employees != null)
            {
                EmployeeExternal? existingEmployee = await _context.Employees
                    .FirstOrDefaultAsync(empl => empl.ExternalId == employeeExternal.ExternalId);

                if (existingEmployee != null)
                {
                    _context.Update(employeeExternal);
                }
            }
        }

        public async Task UpdateServiceExt(ServiceExternal serviceExternal)
        {
            if (_context.Services != null)
            {
                ServiceExternal? existingService = await _context.Services
                    .FirstOrDefaultAsync(service => service.ExternalId == serviceExternal.ExternalId);

                if (existingService != null)
                {
                    _context.Update(serviceExternal);
                }
            }
        }
    }
}
