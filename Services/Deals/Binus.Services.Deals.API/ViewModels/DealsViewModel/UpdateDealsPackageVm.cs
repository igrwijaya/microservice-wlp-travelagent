namespace Binus.Services.Deals.API.ViewModels.DealsViewModel;

public class UpdateDealsPackageVm
{
    public int DealsId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public int Quota { get; set; }

    public decimal Price { get; set; }
}