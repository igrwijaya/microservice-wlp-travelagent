using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationSearchAggregate;
using Binus.Accommodation.Core.Infrastructure.DataSources;

namespace Binus.Accommodation.Core.Infrastructure.Repositories;

public class AccommodationSearchRepository : BaseRepository<AccommodationSearch>, IAccommodationSearchRepository
{
    public AccommodationSearchRepository(CoreDbContext context) : base(context)
    {
    }
}