using Binus.Transaction.Core.Domain.Commons;

namespace Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate;

public class Transaction : CoreEntity, IAggregateRoot
{
    public Transaction()
    {
        
    }

    public Transaction(int customerId, string paymentMethod, string currency, decimal amount, decimal commission)
    {
        CustomerId = customerId;
        PaymentMethod = paymentMethod;
        Currency = currency;
        Amount = amount;
        Commission = commission;
    }
    
    public int CustomerId { get; private set; }

    public string PaymentMethod { get; private set; }

    public string Currency { get; private set; }

    public decimal Amount { get; private set; }

    public decimal Commission { get; private set; }
}