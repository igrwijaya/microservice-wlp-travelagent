using Binus.Accommodation.Core.Domain.Commons;

namespace Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationSearchAggregate;

public class AccommodationSearch : CoreEntity, IAggregateRoot
{
    public AccommodationSearch()
    {
        
    }
    
    public AccommodationSearch(string query, bool isBooked)
    {
        Query = query;
        IsBooked = isBooked;
    }

    public string Query { get; private set; }

    public bool IsBooked { get; private set; }
}