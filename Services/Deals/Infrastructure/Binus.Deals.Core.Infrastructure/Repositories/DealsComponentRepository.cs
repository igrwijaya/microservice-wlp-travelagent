using Binus.Deals.Core.Domain.AggregateRoots.DealsComponentAggregate;
using Binus.Deals.Core.Infrastructure.DataSources;

namespace Binus.Deals.Core.Infrastructure.Repositories;

public class DealsComponentRepository : BaseRepository<DealsComponent>, IDealsComponentRepository
{
    public DealsComponentRepository(CoreDbContext context) : base(context)
    {
    }
}