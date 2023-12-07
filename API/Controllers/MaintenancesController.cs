// <copyright file="MaintenancesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenancesController : ControllerBase
{
    private readonly MaintenancesService service;
    private readonly UnitsService unitService;

    public MaintenancesController(MaintenancesService service, UnitsService unitService)
    {
        this.service = service;
        this.unitService = unitService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaintenance(int id)
    {
        var maintenance = await this.service.GetMaintenanceById(id);
        if (maintenance == null)
        {
            return this.NotFound("Maintenance order not found");
        }

        return this.Ok(maintenance);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Maintenances maintenance)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var unitExist = await this.unitService.GetUnitById(maintenance.UnitID);

        if (unitExist == null)
        {
            return this.NotFound("Unit not found");
        }

        var result = await this.service.CreateMaintenance(maintenance);
        if (result > 0)
        {
            // That could be a DTO
            var response = new
            {
                message = "Maintenance created successfully",
                maintenance,
            };
            return this.Created(nameof(this.Create), response);
        }
        else
        {
            return this.BadRequest("Failed to create Maintenance");
        }
    }
}
