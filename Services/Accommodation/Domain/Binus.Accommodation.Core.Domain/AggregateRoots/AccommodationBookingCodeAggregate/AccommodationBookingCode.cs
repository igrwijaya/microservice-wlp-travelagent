using Binus.Accommodation.Core.Domain.Commons;

namespace Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;

public class AccommodationBookingCode : CoreEntity, IAggregateRoot
{
    public AccommodationBookingCode()
    {
        
    }

    public AccommodationBookingCode(int accommodationGuestId, string code, int customerId)
    {
        AccommodationGuestId = accommodationGuestId;
        Code = code;
        CustomerId = customerId;
    }
    
    public int AccommodationGuestId { get; private set; }

    public string Code { get; private set; }

    public int CustomerId { get; private set; }

    public AccommodationGuest AccommodationGuest { get; set; }
}