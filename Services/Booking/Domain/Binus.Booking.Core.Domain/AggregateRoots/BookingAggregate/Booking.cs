using Binus.Booking.Core.Domain.Commons;

namespace Binus.Booking.Core.Domain.AggregateRoots.BookingAggregate;

public class Booking : CoreEntity, IAggregateRoot
{
    public Booking()
    {
        
    }

    public Booking(int customerId, string virtoTransactionId, string productType, string status, int partnerId)
    {
        CustomerId = customerId;
        VirtoTransactionId = virtoTransactionId;
        ProductType = productType;
        Status = status;
        PartnerId = partnerId;
    }
    
    public int CustomerId { get; private set; }

    public string VirtoTransactionId { get; private set; }

    public string ProductType { get; private set; }

    public string Status { get; private set; }

    public int PartnerId { get; private set; }
}