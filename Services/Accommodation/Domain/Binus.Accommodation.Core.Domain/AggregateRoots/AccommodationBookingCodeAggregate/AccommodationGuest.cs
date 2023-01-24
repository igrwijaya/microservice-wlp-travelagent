using System.Collections.Generic;
using Binus.Accommodation.Core.Domain.Commons;

namespace Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;

public class AccommodationGuest : CoreEntity
{
    public AccommodationGuest()
    {
        
    }

    public AccommodationGuest(int accommodationBookingCodeId, string firstName, string lastName, string gender)
    {
        AccommodationBookingCodeId = accommodationBookingCodeId;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public int AccommodationBookingCodeId { get; private set; }
    
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Gender { get; private set; }

    public List<AccommodationBookingCode> BookingCodes { get; set; }
}