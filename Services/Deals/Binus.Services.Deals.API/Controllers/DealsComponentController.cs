using Binus.Deals.Core.Domain.AggregateRoots.DealsComponentAggregate;
using Binus.Deals.Core.Domain.Commons;
using Binus.Services.Deals.API.ViewModels.DealsComponentViewModel;
using MediatR;

namespace Binus.Services.Deals.API.Controllers;

public class DealsComponentController : CrudController<DealsComponent, CreateDealsComponentVm, UpdateDealsComponentVm>
{
    private readonly IDealsComponentRepository _componentRepository;
    
    public DealsComponentController(IMediator mediator, IDealsComponentRepository componentRepository) : base(mediator)
    {
        _componentRepository = componentRepository;
    }

    public override IBaseRepository<DealsComponent> BaseRepository => _componentRepository;
}