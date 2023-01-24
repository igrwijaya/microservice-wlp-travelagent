using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Binus.Flight.Core.Infrastructure.DataSources;

namespace Binus.Flight.Core.Infrastructure.Repositories;

public class FlightPassengerRepository : BaseRepository<FlightPassenger>, IFlightPassengerRepository
{
    public FlightPassengerRepository(CoreDbContext context) : base(context)
    {
    }
}