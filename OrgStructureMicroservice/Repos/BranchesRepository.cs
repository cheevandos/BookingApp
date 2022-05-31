using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Database;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Repos
{
    public class BranchesRepository : IBranchesRepository
    {
        private readonly OrgStructDbContext _context;

        public BranchesRepository(OrgStructDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateBranch(Branch newBranch)
        {
            if (_context.Branches != null)
            {
                await _context.Branches.AddAsync(newBranch);
            }
        }

        public async Task<Branch?> GetBranch(int branchId)
        {
            if (_context.Branches != null)
            {
                return await _context.Branches
                    .FirstOrDefaultAsync(branch => branch.Id == branchId);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Branch>?> GetBranchesByCompanyId(int companyId)
        {
            if (_context.Branches != null)
            {
                return await _context.Branches
                    .Where(branch => branch.CompanyId == companyId)
                    .ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
