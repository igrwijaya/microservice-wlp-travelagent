using Binus.Flight.Core.Domain.Commons;

namespace Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;

public class FlightTicket : CoreEntity
{
    public FlightTicket()
    {
        
    }
    
    public FlightTicket(int flightPassengerId, string pnr, string departure, string arrival, string airline)
    {
        FlightPassengerId = flightPassengerId;
        Pnr = pnr;
        Departure = departure;
        Arrival = arrival;
        Airline = airline;
    }

    public int FlightPassengerId { get; private set; }

    public string Pnr { get; private set; }

    public string Departure { get; private set; }

    public string Arrival { get; private set; }

    public string Airline { get; private set; }

    public FlightPassenger FlightPassenger { get; set; }
}