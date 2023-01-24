using Binus.Deals.Core.Domain.Commons;

namespace Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;

public class DealsPackage : CoreEntity
{
    public DealsPackage()
    {
        
    }
    
    public DealsPackage(int dealsId, string title, string description, string image, int quota, decimal price)
    {
        DealsId = dealsId;
        Title = title;
        Description = description;
        Image = image;
        Quota = quota;
        Price = price;
    }

    public int DealsId { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Image { get; private set; }

    public int Quota { get; private set; }

    public decimal Price { get; private set; }

    public Deals Deals { get; set; }
}