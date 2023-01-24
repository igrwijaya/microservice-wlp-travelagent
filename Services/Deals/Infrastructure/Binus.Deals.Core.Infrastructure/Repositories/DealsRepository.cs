using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Infrastructure.DataSources;

namespace Binus.Deals.Core.Infrastructure.Repositories;

public class DealsRepository : BaseRepository<Domain.AggregateRoots.DealsAggregate.Deals>, IDealsRepository
{
    public DealsRepository(CoreDbContext context) : base(context)
    {
    }
}