using Binus.Flight.Core.Domain.AggregateRoots.FlightSearchAggregate;
using Binus.Flight.Core.Infrastructure.DataSources;

namespace Binus.Flight.Core.Infrastructure.Repositories;

public class FlightSearchRepository : BaseRepository<FlightSearch>, IFlightSearchRepository
{
    public FlightSearchRepository(CoreDbContext context) : base(context)
    {
    }
}