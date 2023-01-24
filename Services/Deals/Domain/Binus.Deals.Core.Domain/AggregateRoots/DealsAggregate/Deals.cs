using System;
using System.Collections.Generic;
using Binus.Deals.Core.Domain.Commons;

namespace Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;

public class Deals : CoreEntity, IAggregateRoot
{
    public Deals()
    {
        
    }
    
    public Deals(string title, string description, DateTime availabilityStartDate, DateTime availabilityEndDate, string policies)
    {
        Title = title;
        Description = description;
        AvailabilityStartDate = availabilityStartDate;
        AvailabilityEndDate = availabilityEndDate;
        Policies = policies;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime AvailabilityStartDate { get; private set; }

    public DateTime AvailabilityEndDate { get; private set; }

    public string Policies { get; private set; }

    public List<DealsPackage> DealsPackages { get; set; }
}