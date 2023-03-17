using System.Collections.Generic;
using Binus.Accommodation.Core.Domain.Commons;

namespace Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;

public class AccommodationBookingCode : CoreEntity, IAggregateRoot
{
    public AccommodationBookingCode()
    {
        
    }

    public AccommodationBookingCode(string code, int customerId, int updateMigration, string anotherProp)
    {
        Code = code;
        CustomerId = customerId;
        UpdateMigration = updateMigration;
        AnotherProp = anotherProp;
    }

    public string Code { get; private set; }

    public int CustomerId { get; private set; }

    public int UpdateMigration { get; private set; }

    public string AnotherProp { get; private set; }

    public List<AccommodationGuest> AccommodationGuests { get; set; }
}