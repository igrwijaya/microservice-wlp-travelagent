using Binus.Services.Transaction.API.ViewModels.TransactionViewModel;
using Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate;
using Binus.Transaction.Core.Domain.Commons;
using MediatR;

namespace Binus.Services.Transaction.API.Controllers;

public class TransactionsController : CrudController<Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate.Transaction, CreateTransactionVm, UpdateTransactionVm>
{
    private readonly ITransactionRepository _transactionRepository;
    
    public TransactionsController(IMediator mediator, ITransactionRepository transactionRepository) : base(mediator)
    {
        _transactionRepository = transactionRepository;
    }

    public override IBaseRepository<Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate.Transaction>
        BaseRepository
        => _transactionRepository;
}