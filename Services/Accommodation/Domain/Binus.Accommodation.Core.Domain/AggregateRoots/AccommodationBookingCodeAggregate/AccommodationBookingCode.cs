using System.Collections.Generic;
using Binus.Accommodation.Core.Domain.Commons;

namespace Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;

public class AccommodationBookingCode : CoreEntity, IAggregateRoot
{
    public AccommodationBookingCode()
    {
        
    }

    public AccommodationBookingCode(string code, int customerId)
    {
        Code = code;
        CustomerId = customerId;
    }

    public string Code { get; private set; }

    public int CustomerId { get; private set; }

    public List<AccommodationGuest> AccommodationGuests { get; set; }
}