namespace Binus.Services.Transaction.API.ViewModels.BookingViewModel;

public class CreateBookingVm
{
    public int CustomerId { get; set; }

    public string VirtoTransactionId { get; set; }

    public string ProductType { get; set; }

    public string Status { get; set; }

    public int PartnerId { get; set; }
}