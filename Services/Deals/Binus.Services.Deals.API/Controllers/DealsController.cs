using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Domain.Commons;
using Binus.Services.Deals.API.ViewModels.DealsViewModel;
using MediatR;

namespace Binus.Services.Deals.API.Controllers;

public class DealsController : CrudController<Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate.Deals, CreateDealsVm, UpdateDealsVm>
{
    protected readonly IDealsRepository DealsRepository;
    
    public DealsController(IMediator mediator, IDealsRepository dealsRepository) : base(mediator)
    {
        DealsRepository = dealsRepository;
    }

    public override IBaseRepository<Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate.Deals> BaseRepository =>
        DealsRepository;
}