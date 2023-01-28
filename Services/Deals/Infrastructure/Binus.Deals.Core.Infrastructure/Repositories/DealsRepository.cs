using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Domain.Commons;
using Binus.Deals.Core.Infrastructure.DataSources;
using Microsoft.EntityFrameworkCore;

namespace Binus.Deals.Core.Infrastructure.Repositories;

public class DealsRepository : BaseRepository<Domain.AggregateRoots.DealsAggregate.Deals>, IDealsRepository
{
    public DealsRepository(CoreDbContext context) : base(context)
    {
    }

    public Task<Domain.AggregateRoots.DealsAggregate.Deals> ReadWithPackagesAsync(int id)
    {
        return ReadAsync(delegate(DbSet<Domain.AggregateRoots.DealsAggregate.Deals> set)
        {
            return set.Include(item => item.DealsPackages);
        }, item => item.Id == id);
    }

    public CoreDataTable<DealsPackage> GetDataTablePackages(int dealsId, int page, int size)
    {
        var dbSet = Context.Set<DealsPackage>();
        var dealsPackages = dbSet.Where(item => item.DealsId == dealsId);
        
        return GetDataTable(
            dealsPackages,
            new CoreDataTableParameter
        {
            Start = page,
            Length = size,
            SortColumn = nameof(CoreEntity.CreatedDateTime),
            SortColumnDirection = "DESC"
        }, set => set);
    }

    public IEnumerable<DealsPackage> GetPackages(int dealsId, int page, int size)
    {
        var dbSet = Context.Set<DealsPackage>();
        var dealsPackageEntity = dbSet.AsQueryable().Where(item => item.DealsId == dealsId);

        return Get(dealsPackageEntity, page, size);
    }

    public async Task<DealsPackage> ReadPackageAsync(int dealsId, int packageId)
    {
        var dbSet = Context.Set<DealsPackage>();

        return await dbSet.FirstOrDefaultAsync(item => item.DealsId == dealsId && item.Id == packageId);
    }

    public async Task UpdatePackageAsync(DealsPackage dealsPackage)
    {
        Context.Entry(dealsPackage).State = EntityState.Modified;
        
        await Context.SaveChangesAsync();
    }

    public async Task DeletePackageAsync(int dealsId, int packageId)
    {
        var dbSet = Context.Set<DealsPackage>();
        var entity = await ReadPackageAsync(dealsId, packageId);

        if (entity == null)
        {
            return;
        }

        dbSet.Remove(entity);

        await Context.SaveChangesAsync();
    }
}