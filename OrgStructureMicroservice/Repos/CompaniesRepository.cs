using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Database;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Repos
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly OrgStructDbContext _context;

        public CompaniesRepository(OrgStructDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>?> GetAllCompanies()
        {
            if (_context.Companies != null)
            {
                return await _context.Companies.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            if (_context.Companies != null)
            {
                return await _context.Companies
                    .FirstOrDefaultAsync(company => company.Id == id);
            }
            else
            {
                return null;
            }
        }
    }
}
