using Aplication.Interfaces.Packages;
using Domain.AggregateRoots.Package;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Packages
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(BackendDBContext context)
            : base(context)
        {
        }

      
        public async Task<Package?> GetFullPackageByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
