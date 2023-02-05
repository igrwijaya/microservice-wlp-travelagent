using System.Threading.Tasks;
using Binus.Deals.Core.Application.Services;
using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Domain.Commons;
using Binus.Services.Deals.API.ViewModels.DealsViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Deals.API.Controllers;

public class DealsController : CrudController<Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate.Deals, CreateDealsVm, UpdateDealsVm>
{
    protected readonly IDealsRepository DealsRepository;
    protected readonly IQueueService _queueService;
    
    public DealsController(IMediator mediator, IDealsRepository dealsRepository, IQueueService queueService) : base(mediator)
    {
        DealsRepository = dealsRepository;
        _queueService = queueService;
    }

    public override IBaseRepository<Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate.Deals> BaseRepository =>
        DealsRepository;

    [HttpGet]
    public async Task<ActionResult> TestMessage()
    {
        await _queueService.SendQueueAsync("binus", "message was here");
        return Ok();
    }
}