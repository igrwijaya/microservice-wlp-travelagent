using System;
using System.Collections.Generic;
using Binus.Flight.Core.Domain.Commons;

namespace Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;

public class FlightPassenger : CoreEntity, IAggregateRoot
{
    public FlightPassenger()
    {
        
    }
    
    public FlightPassenger(string passportNumber, string firstName, string lastName, DateTime birthday)
    {
        PassportNumber = passportNumber;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
    }

    public string PassportNumber { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime Birthday { get; private set; }

    public List<FlightTicket> Tickets { get; set; }
}