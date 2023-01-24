using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Binus.Partner.Core.Infrastructure.DataSources;

namespace Binus.Partner.Core.Infrastructure.Repositories;

public class PartnerRepository : BaseRepository<Domain.AggregateRoots.PartnerAggregate.Partner>, IPartnerRepository
{
    public PartnerRepository(CoreDbContext context) : base(context)
    {
    }
}