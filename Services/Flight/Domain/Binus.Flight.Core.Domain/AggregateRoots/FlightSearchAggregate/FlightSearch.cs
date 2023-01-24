using Binus.Flight.Core.Domain.Commons;

namespace Binus.Flight.Core.Domain.AggregateRoots.FlightSearchAggregate;

public class FlightSearch : CoreEntity, IAggregateRoot
{
    public FlightSearch()
    {
        
    }

    public FlightSearch(string query, bool isBooked)
    {
        Query = query;
        IsBooked = isBooked;
    }
    
    public string Query { get; private set; }

    public bool IsBooked { get; private set; }
}