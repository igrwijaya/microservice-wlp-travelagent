namespace Binus.Services.Flight.API.ViewModels.FlightPassengerViewModel;

public class UpdateFlightTicketVm
{
    public int FlightPassengerId { get; set; }

    public string Pnr { get; set; }

    public string Departure { get; set; }

    public string Arrival { get; set; }

    public string Airline { get; set; }
}