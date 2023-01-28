using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Binus.Flight.Core.Domain.Commons;
using Binus.Flight.Core.Infrastructure.DataSources;
using Microsoft.EntityFrameworkCore;

namespace Binus.Flight.Core.Infrastructure.Repositories;

public class FlightPassengerRepository : BaseRepository<FlightPassenger>, IFlightPassengerRepository
{
    public FlightPassengerRepository(CoreDbContext context) : base(context)
    {
    }

    public Task<FlightPassenger> ReadWithTicketsAsync(int id)
    {
        return ReadAsync(delegate(DbSet<FlightPassenger> set)
        {
            return set.Include(item => item.Tickets);
        }, item => item.Id == id);
    }

    public CoreDataTable<FlightTicket> GetDataTableTickets(int flightPassengerId, int page, int size)
    {
        var dbSet = Context.Set<FlightTicket>();
        var flightTickets = dbSet.Where(item => item.FlightPassengerId == flightPassengerId);
        
        return GetDataTable(
            flightTickets,
            new CoreDataTableParameter
            {
                Start = page,
                Length = size,
                SortColumn = nameof(CoreEntity.CreatedDateTime),
                SortColumnDirection = "DESC"
            }, set => set);
    }

    public IEnumerable<FlightTicket> GetTickets(int flightPassengerId, int page, int size)
    {
        var dbSet = Context.Set<FlightTicket>();
        var dealsPackageEntity = dbSet.AsQueryable().Where(item => item.FlightPassengerId == flightPassengerId);

        return Get(dealsPackageEntity, page, size);
    }

    public async Task<FlightTicket> ReadTicketAsync(int flightPassengerId, int flightTicketId)
    {
        var dbSet = Context.Set<FlightTicket>();

        return await dbSet.FirstOrDefaultAsync(item => item.FlightPassengerId == flightPassengerId && item.Id == flightTicketId);
    }

    public async Task UpdateTicketAsync(FlightTicket flightTicket)
    {
        Context.Entry(flightTicket).State = EntityState.Modified;
        
        await Context.SaveChangesAsync();
    }

    public async Task DeleteTicketAsync(int flightPassengerId, int flightTicketId)
    {
        var dbSet = Context.Set<FlightTicket>();
        var entity = await ReadTicketAsync(flightPassengerId, flightTicketId);

        if (entity == null)
        {
            return;
        }

        dbSet.Remove(entity);

        await Context.SaveChangesAsync();
    }
}