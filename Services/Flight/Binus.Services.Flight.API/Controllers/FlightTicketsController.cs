using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Binus.Flight.Core.Domain.Commons;
using Binus.Services.Flight.API.ViewModels.FlightPassengerViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Flight.API.Controllers;

public class FlightTicketsController : FlightPassengersController
{
    public FlightTicketsController(IMediator mediator, IFlightPassengerRepository flightPassengerRepository) : base(mediator, flightPassengerRepository)
    {
    }
        
    #region APIs

    [HttpPost("/FlightPassengers/{flightPassengerId}/Tickets")]
    [Consumes("application/json")]
    public async Task<ActionResult<FlightTicket>> CreateTicket(int flightPassengerId, [FromBody] CreateFlightTicketVm viewModel)
    {
        var @params = new List<object>();

        var prop = viewModel.GetType().GetProperties();
        foreach (var propertyInfo in prop)
        {
            if (propertyInfo.PropertyType.Name == nameof(IFormFile))
            {
                @params.Add(string.Empty);
            }
            else
            {
                var value = propertyInfo.GetValue(viewModel);
                @params.Add(value);
            }
        }

        var model = (FlightTicket)Activator.CreateInstance(typeof(FlightTicket), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }
        
        var flightPassenger = await FlightPassengerRepository.ReadWithTicketsAsync(flightPassengerId);
        if (flightPassenger == null)
        {
            return BadRequest();
        }
        
        flightPassenger.Tickets.Add(model);

        await BaseRepository.UpdateAsync(flightPassenger);

        return Ok(model.Id);
    }

    [HttpGet("/FlightPassengers/{flightPassengerId}/Tickets/DataTable")]
    [AllowAnonymous]
    public ActionResult<CoreDataTable<FlightTicket>> GetDataTableTicket(int flightPassengerId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var paginateResponse = FlightPassengerRepository.GetDataTableTickets(flightPassengerId, page, size);
        
        return paginateResponse;
    }

    [HttpGet("/FlightPassengers/{flightPassengerId}/Tickets")]
    [AllowAnonymous]
    public ActionResult<List<FlightTicket>> GetTicket(int flightPassengerId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var response = FlightPassengerRepository.GetTickets(flightPassengerId, page, size);

        return response.ToList();
    }

    [HttpGet("/FlightPassengers/{flightPassengerId}/Tickets/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<FlightTicket>> ReadTicket(int flightPassengerId, int id)
    {
        var response = await FlightPassengerRepository.ReadTicketAsync(flightPassengerId, id);

        return response;
    }

    [HttpPut("/FlightPassengers/{flightPassengerId}/Tickets/{id}")]
    public async Task<ActionResult> UpdateTicket(int flightPassengerId, int id, [FromBody] UpdateFlightTicketVm viewModel)
    {
        var @params = new List<object>();

        var prop = viewModel.GetType().GetProperties();
        foreach (var propertyInfo in prop)
        {
            if (propertyInfo.PropertyType.Name == nameof(IFormFile))
            {
                @params.Add(string.Empty);
            }
            else
            {
                var value = propertyInfo.GetValue(viewModel);
                @params.Add(value);
            }
        }

        var model = (FlightTicket)Activator.CreateInstance(typeof(FlightTicket), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }
        
        var response = await FlightPassengerRepository.ReadTicketAsync(flightPassengerId, id);
        if (response == null)
        {
            return BadRequest();
        }
        
        model.AttachAuditableEntity(response);
        
        await FlightPassengerRepository.UpdateTicketAsync(model);

        return Ok();
    }

    [HttpDelete("/FlightPassengers/{flightPassengerId}/Tickets/{id}")]
    public async Task<ActionResult> DeleteTicket(int flightPassengerId, int id)
    {
        await FlightPassengerRepository.DeleteTicketAsync(flightPassengerId, id);

        return Ok();
    }

    #endregion
}