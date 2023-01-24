using Binus.Booking.Core.Domain.AggregateRoots.BookingAggregate;
using Binus.Booking.Core.Infrastructure.DataSources;

namespace Binus.Booking.Core.Infrastructure.Repositories;

public class BookingRepository : BaseRepository<Domain.AggregateRoots.BookingAggregate.Booking>, IBookingRepository
{
    public BookingRepository(CoreDbContext context) : base(context)
    {
    }
}