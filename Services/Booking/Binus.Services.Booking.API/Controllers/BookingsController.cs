using Binus.Booking.Core.Domain.AggregateRoots.BookingAggregate;
using Binus.Booking.Core.Domain.Commons;
using Binus.Services.Transaction.API.ViewModels.BookingViewModel;
using MediatR;

namespace Binus.Services.Transaction.API.Controllers;

public class BookingsController : CrudController<Booking.Core.Domain.AggregateRoots.BookingAggregate.Booking, CreateBookingVm, UpdateBookingVm>
{
    private readonly IBookingRepository _bookingRepository;
    
    public BookingsController(IMediator mediator, IBookingRepository bookingRepository) : base(mediator)
    {
        _bookingRepository = bookingRepository;
    }

    public override IBaseRepository<Booking.Core.Domain.AggregateRoots.BookingAggregate.Booking> BaseRepository =>
        _bookingRepository;
}