using Binus.Deals.Core.Domain.Commons;

namespace Binus.Deals.Core.Domain.AggregateRoots.DealsComponentAggregate;

public class DealsComponent : CoreEntity, IAggregateRoot
{
    public DealsComponent()
    {
        
    }
    
    public DealsComponent(string type, string title, string productId, int quantity, decimal unitPrice)
    {
        Type = type;
        Title = title;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public string Type { get; private set; }

    public string Title { get; private set; }

    public string ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }
}