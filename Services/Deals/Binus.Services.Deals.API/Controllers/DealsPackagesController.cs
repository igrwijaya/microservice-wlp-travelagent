using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Domain.Commons;
using Binus.Services.Deals.API.ViewModels.DealsViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Deals.API.Controllers;

public class DealsPackagesController : DealsController
{
    public DealsPackagesController(IMediator mediator, IDealsRepository dealsRepository) : base(mediator, dealsRepository)
    {
    }
    
    #region APIs

    [HttpPost("/Deals/{dealsId}/Packages")]
    [Consumes("application/json")]
    public async Task<ActionResult<DealsPackage>> CreatePackage(int dealsId, [FromBody] CreateDealsPackageVm viewModel)
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

        var model = (DealsPackage)Activator.CreateInstance(typeof(DealsPackage), @params.ToArray());

        var deals = await DealsRepository.ReadWithPackagesAsync(dealsId);
        if (deals == null)
        {
            return BadRequest();
        }
        
        deals.DealsPackages.Add(model);

        await BaseRepository.UpdateAsync(deals);

        return Ok(model.Id);
    }

    [HttpGet("/Deals/{dealsId}/Packages/DataTable")]
    [AllowAnonymous]
    public ActionResult<CoreDataTable<DealsPackage>> GetDataTablePackage(int dealsId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var paginateResponse = DealsRepository.GetDataTablePackages(dealsId, page, size);
        
        return paginateResponse;
    }

    [HttpGet("/Deals/{dealsId}/Packages")]
    [AllowAnonymous]
    public ActionResult<List<DealsPackage>> GetPackage(int dealsId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var response = DealsRepository.GetPackages(dealsId, page, size);

        return response.ToList();
    }

    [HttpGet("/Deals/{dealsId}/Packages/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<DealsPackage>> ReadPackage(int dealsId, int id)
    {
        var response = await DealsRepository.ReadPackageAsync(dealsId, id);

        return response;
    }

    [HttpPut("/Deals/{dealsId}/Packages/{id}")]
    public async Task<ActionResult> UpdatePackage(int dealsId, int id, [FromBody] UpdateDealsPackageVm viewModel)
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

        var model = (DealsPackage)Activator.CreateInstance(typeof(DealsPackage), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }
        
        var response = await DealsRepository.ReadPackageAsync(dealsId, id);
        if (response == null)
        {
            return BadRequest();
        }
        
        model.AttachAuditableEntity(response);
        
        await DealsRepository.UpdatePackageAsync(model);

        return Ok();
    }

    [HttpDelete("/Deals/{dealsId}/Packages/{id}")]
    public async Task<ActionResult> DeletePackage(int dealsId, int id)
    {
        await DealsRepository.DeletePackageAsync(dealsId, id);

        return Ok();
    }

    #endregion
}