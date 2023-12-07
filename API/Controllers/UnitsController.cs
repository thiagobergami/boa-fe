// <copyright file="UnitsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Globalization;
using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnitsController : ControllerBase
{
    private readonly UnitsService service;
    private readonly ClientService clientsService;

    public UnitsController(UnitsService service, ClientService clientService)
    {
        this.service = service;
        this.clientsService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUnits()
    {
        var units = await this.service.GetAllUnits();
        return this.Ok(units);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUnit([FromBody] Units unit)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var createdUnit = await this.service.CreateUnit(unit);

        return this.CreatedAtAction(nameof(this.CreateUnit), new { id = createdUnit.Id }, createdUnit);
    }

    [HttpPost("{id}/rent-unit")]
    public async Task<IActionResult> RentUnit(int id, [FromBody] UpdateTenantInfoDTO tenantClient)
    {
        var unitExist = await this.service.GetUnitById(id);
        var clientExist = await this.clientsService.FindClientById(tenantClient.TenantClientId);

        if (unitExist == null || clientExist == null)
        {
            return this.NotFound("Not found");
        }

        unitExist.TenantStartedAt = DateTime.ParseExact(tenantClient.TenantStartedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        unitExist.TenantFinishedAt = DateTime.ParseExact(tenantClient.TenantFinishedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        unitExist.TenantClientId = tenantClient.TenantClientId;

        var rentUnit = await this.service.RentUnit(unitExist);

        if (rentUnit > 0)
        {
            // That could be a DTO
            return this.Created($"Unit {id} Rented with success", null);
        }
        else
        {
            return this.BadRequest("Failed to create Maintenance");
        }
    }
}
