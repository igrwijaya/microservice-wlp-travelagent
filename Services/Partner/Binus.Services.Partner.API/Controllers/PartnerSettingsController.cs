﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Binus.Partner.Core.Domain.Commons;
using Binus.Services.Partner.API.ViewModels.PartnerViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Partner.API.Controllers;

public class PartnerSettingsController : PartnersController
{
    public PartnerSettingsController(IMediator mediator, IPartnerRepository partnerRepository) : base(mediator, partnerRepository)
    {
    }
    
    #region APIs

    [HttpPost("/Partners/{partnerId}/Settings")]
    [Consumes("application/json")]
    public async Task<ActionResult<PartnerSetting>> CreateSetting(int partnerId, [FromBody] CreatePartnerSettingVm viewModel)
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

        var model = (PartnerSetting)Activator.CreateInstance(typeof(PartnerSetting), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }

        var deals = await PartnerRepository.ReadWithSettingsAsync(partnerId);
        if (deals == null)
        {
            return BadRequest();
        }
        
        deals.Settings.Add(model);

        await BaseRepository.UpdateAsync(deals);

        return Ok(model.Id);
    }

    [HttpGet("/Partners/{partnerId}/Settings/DataTable")]
    [AllowAnonymous]
    public ActionResult<CoreDataTable<PartnerSetting>> GetDataTableSetting(int partnerId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var paginateResponse = PartnerRepository.GetDataTableSettings(partnerId, page, size);
        
        return paginateResponse;
    }

    [HttpGet("/Partners/{partnerId}/Settings")]
    [AllowAnonymous]
    public ActionResult<List<PartnerSetting>> GetSetting(int partnerId, [FromQuery] int page = 1, [FromQuery] int size = -1)
    {
        var response = PartnerRepository.GetSettings(partnerId, page, size);

        return response.ToList();
    }

    [HttpGet("/Partners/{partnerId}/Settings/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<PartnerSetting>> ReadSetting(int partnerId, int id)
    {
        var response = await PartnerRepository.ReadSettingAsync(partnerId, id);

        return response;
    }

    [HttpPut("/Partners/{partnerId}/Settings/{id}")]
    public async Task<ActionResult> UpdateSetting(int partnerId, int id, [FromBody] UpdatePartnerSettingVm viewModel)
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

        var model = (PartnerSetting)Activator.CreateInstance(typeof(PartnerSetting), @params.ToArray());
        if (model == null)
        {
            return BadRequest();
        }
        
        var response = await PartnerRepository.ReadSettingAsync(partnerId, id);
        if (response == null)
        {
            return BadRequest();
        }
        
        model.AttachAuditableEntity(response);
        
        await PartnerRepository.UpdateSettingAsync(model);

        return Ok();
    }

    [HttpDelete("/Partners/{partnerId}/Settings/{id}")]
    public async Task<ActionResult> DeleteSetting(int partnerId, int id)
    {
        await PartnerRepository.DeleteSettingAsync(partnerId, id);

        return Ok();
    }

    #endregion
}