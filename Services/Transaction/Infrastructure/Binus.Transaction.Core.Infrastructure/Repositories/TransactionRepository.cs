using Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate;
using Binus.Transaction.Core.Infrastructure.DataSources;

namespace Binus.Transaction.Core.Infrastructure.Repositories;

public class TransactionRepository : BaseRepository<Domain.AggregateRoots.TransactionAggregate.Transaction>, ITransactionRepository
{
    public TransactionRepository(CoreDbContext context) : base(context)
    {
    }
}