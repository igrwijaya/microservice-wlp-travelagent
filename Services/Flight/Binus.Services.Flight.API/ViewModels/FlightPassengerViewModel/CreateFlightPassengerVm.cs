using System;

namespace Binus.Services.Flight.API.ViewModels.FlightPassengerViewModel;

public class CreateFlightPassengerVm
{
    public string PassportNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }
}