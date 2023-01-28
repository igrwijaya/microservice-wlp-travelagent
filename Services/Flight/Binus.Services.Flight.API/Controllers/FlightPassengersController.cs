using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Binus.Flight.Core.Domain.Commons;
using Binus.Services.Flight.API.ViewModels.FlightPassengerViewModel;
using MediatR;

namespace Binus.Services.Flight.API.Controllers;

public class FlightPassengersController : CrudController<FlightPassenger, CreateFlightPassengerVm, UpdateFlightPassengerVm>
{
    protected readonly IFlightPassengerRepository FlightPassengerRepository;
    
    public FlightPassengersController(IMediator mediator, IFlightPassengerRepository flightPassengerRepository) : base(mediator)
    {
        FlightPassengerRepository = flightPassengerRepository;
    }

    public override IBaseRepository<FlightPassenger> BaseRepository => FlightPassengerRepository;
}