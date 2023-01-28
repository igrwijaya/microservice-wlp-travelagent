using System;

namespace Binus.Services.Deals.API.ViewModels.DealsViewModel;

public class CreateDealsVm
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime AvailabilityStartDate { get; set; }

    public DateTime AvailabilityEndDate { get; set; }

    public string Policies { get; set; }
}