using Binus.Flight.Core.Domain.AggregateRoots.FlightSearchAggregate;
using Binus.Flight.Core.Domain.Commons;
using Binus.Services.Flight.API.ViewModels.FlightSearchViewModel;
using MediatR;

namespace Binus.Services.Flight.API.Controllers;

public class FlightSearchesController : CrudController<FlightSearch, CreateFlightSearchVm, UpdateFlightSearchVm>
{
    private readonly IFlightSearchRepository _flightSearchRepository;
    
    public FlightSearchesController(IMediator mediator, IFlightSearchRepository flightSearchRepository) : base(mediator)
    {
        _flightSearchRepository = flightSearchRepository;
    }

    public override IBaseRepository<FlightSearch> BaseRepository => _flightSearchRepository;
}