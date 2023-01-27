using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.Activities.Core.Domain.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Activities.API.Controllers;

public abstract class CrudController<TModel, TCreateViewModel, TUpdateViewModel>  : BaseController
    where TModel : CoreEntity, IAggregateRoot
    where TCreateViewModel : class, new()
    where TUpdateViewModel : class, new()
{
    public abstract IBaseRepository<TModel> BaseRepository { get; }
    
    public CrudController(IMediator mediator) : base(mediator)
    {
    }

    #region APIs

    [HttpPost("/[controller]")]
    [Consumes("application/json")]
    public async Task<ActionResult<TModel>> Create([FromBody] TCreateViewModel viewModel)
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

        var model = (TModel)Activator.CreateInstance(typeof(TModel), @params.ToArray());

        var response = await BaseRepository.CreateAsync(model);

        return Ok(response);
    }

    [HttpGet("/[controller]/DataTable")]
    [AllowAnonymous]
    public ActionResult<CoreDataTable<TModel>> GetDataTable([FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var paginateResponse = BaseRepository.GetDataTable(page, size);
        return Ok(paginateResponse);
    }

    [HttpGet("/[controller]")]
    [AllowAnonymous]
    public ActionResult<List<TModel>> Get([FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var response = BaseRepository.Get(page, size);

        return Ok(response);
    }

    [HttpGet("/[controller]/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<TModel>> Read(int id)
    {
        var response = await BaseRepository.ReadAsync(id);

        return Ok(response);
    }

    [HttpPut("/[controller]/{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] TUpdateViewModel viewModel)
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

        var model = (TModel)Activator.CreateInstance(typeof(TModel), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }
        
        var response = await BaseRepository.ReadAsync(id);
        if (response == null)
        {
            return BadRequest();
        }
        
        model.AttachAuditableEntity(response);
        
        await BaseRepository.UpdateAsync(model);

        return Ok();
    }

    [HttpDelete("/[controller]/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await BaseRepository.DeleteAsync(id);

        return Ok();
    }

    #endregion
}