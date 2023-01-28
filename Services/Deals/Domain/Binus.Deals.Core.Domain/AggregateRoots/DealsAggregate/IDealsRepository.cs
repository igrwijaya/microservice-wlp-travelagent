using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Deals.Core.Domain.Commons;

namespace Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;

public interface IDealsRepository : IBaseRepository<Deals>
{
    #region Deals Packages

    Task<Deals> ReadWithPackagesAsync(int id);
    
    CoreDataTable<DealsPackage> GetDataTablePackages(int dealsId, int page, int size);
    
    IEnumerable<DealsPackage> GetPackages(int dealsId, int page, int size);

    Task<DealsPackage> ReadPackageAsync(int dealsId, int packageId);

    Task UpdatePackageAsync(DealsPackage dealsPackage);

    Task DeletePackageAsync(int dealsId, int packageId);

    #endregion
}