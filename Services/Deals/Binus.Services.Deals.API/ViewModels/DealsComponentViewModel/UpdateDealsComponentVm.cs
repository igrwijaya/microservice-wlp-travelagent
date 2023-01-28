namespace Binus.Services.Deals.API.ViewModels.DealsComponentViewModel;

public class UpdateDealsComponentVm
{
    public string Type { get; set; }

    public string Title { get; set; }

    public string ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}