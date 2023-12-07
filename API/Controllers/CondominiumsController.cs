// <copyright file="CondominiumsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CondominiumsController : ControllerBase
{
    private readonly CondominiumsService service;

    public CondominiumsController(CondominiumsService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Condominiums condom)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var result = await this.service.CreateCondominium(condom);

        if (result > 0)
        {
            // That could be a DTO
            var response = new
            {
                message = "Client created successfully",
                condominium = condom,
            };
            return this.Created(nameof(this.Create), response);
        }
        else
        {
            return this.BadRequest("Failed to create client");
        }
    }

    [HttpPost("{condominiumId}/associate-units")]
    public async Task<ActionResult> AssociateUnits(int condominiumId, [FromBody] List<int> unitIds)
    {
        var condominium = await this.service.GetCondominiumsById(condominiumId);

        if (condominium == null)
        {
            return this.NotFound("Condominum not found");
        }

        var unitAssociated = await this.service.AssociateUnitsWithCondominium(condominiumId, unitIds);

        if (unitAssociated)
        {
            return this.Created($"Units associated with Condominium {condominiumId} successfully", null);
        }
        else
        {
            return this.BadRequest("Failed to create client");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCondominum(int id)
    {
        var condominium = await this.service.GetCondominiumsById(id);

        if (condominium == null)
        {
            return this.NotFound("Condominum not found");
        }

        return this.Ok(condominium);
    }
}
