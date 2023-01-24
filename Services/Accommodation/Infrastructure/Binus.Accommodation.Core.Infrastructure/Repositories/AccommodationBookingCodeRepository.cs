using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;
using Binus.Accommodation.Core.Infrastructure.DataSources;

namespace Binus.Accommodation.Core.Infrastructure.Repositories;

public class AccommodationBookingCodeRepository : BaseRepository<AccommodationBookingCode>, IAccommodationBookingCodeRepository
{
    public AccommodationBookingCodeRepository(CoreDbContext context) : base(context)
    {
    }
}