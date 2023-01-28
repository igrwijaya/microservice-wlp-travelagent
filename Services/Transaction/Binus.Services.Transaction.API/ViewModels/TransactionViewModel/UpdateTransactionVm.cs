namespace Binus.Services.Transaction.API.ViewModels.TransactionViewModel;

public class UpdateTransactionVm
{
    public int CustomerId { get; set; }

    public string PaymentMethod { get; set; }

    public string Currency { get; set; }

    public decimal Amount { get; set; }

    public decimal Commission { get; set; }
}