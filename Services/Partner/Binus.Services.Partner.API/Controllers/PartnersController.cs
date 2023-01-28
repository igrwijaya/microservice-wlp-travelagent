using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Binus.Partner.Core.Domain.Commons;
using Binus.Services.Partner.API.ViewModels.PartnerViewModel;
using MediatR;

namespace Binus.Services.Partner.API.Controllers;

public class PartnersController : CrudController<Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate.Partner, CreatePartnerVm, UpdatePartnerVm>
{
    protected readonly IPartnerRepository PartnerRepository;
    
    public PartnersController(IMediator mediator, IPartnerRepository partnerRepository) : base(mediator)
    {
        PartnerRepository = partnerRepository;
    }

    public override IBaseRepository<Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate.Partner> BaseRepository
        => PartnerRepository;
}