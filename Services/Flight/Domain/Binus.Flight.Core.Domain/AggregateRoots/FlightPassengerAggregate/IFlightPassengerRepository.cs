using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Flight.Core.Domain.Commons;

namespace Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;

public interface IFlightPassengerRepository : IBaseRepository<FlightPassenger>
{
    #region Flight Tickets

    Task<FlightPassenger> ReadWithTicketsAsync(int id);
    
    CoreDataTable<FlightTicket> GetDataTableTickets(int flightPassengerId, int page, int size);
    
    IEnumerable<FlightTicket> GetTickets(int flightPassengerId, int page, int size);

    Task<FlightTicket> ReadTicketAsync(int flightPassengerId, int flightTicketId);

    Task UpdateTicketAsync(FlightTicket flightTicket);

    Task DeleteTicketAsync(int flightPassengerId, int flightTicketId);

    #endregion
}