using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;
using Binus.Accommodation.Core.Domain.Commons;
using Binus.Services.Accommodation.API.ViewModels.AccommodationBookingCodeViewModels;
using MediatR;

namespace Binus.Services.Accommodation.API.Controllers;

public class AccommodationBookingCodesController : CrudController<AccommodationBookingCode, CreateAccommodationBookingCodeVm, UpdateAccommodationBookingCodeVm>
{
    private readonly IAccommodationBookingCodeRepository _accommodationBookingCodeRepository;
    
    public AccommodationBookingCodesController(IMediator mediator, IAccommodationBookingCodeRepository accommodationBookingCodeRepository) : base(mediator)
    {
        _accommodationBookingCodeRepository = accommodationBookingCodeRepository;
    }

    public override IBaseRepository<AccommodationBookingCode> BaseRepository => _accommodationBookingCodeRepository;
}