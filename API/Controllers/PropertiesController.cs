// <copyright file="PropertiesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly PropertiesService service;
    private readonly ClientService clientService;
    private readonly UnitsService unitService;

    public PropertiesController(PropertiesService service, ClientService clientService, UnitsService unitService)
    {
        this.service = service;
        this.clientService = clientService;
        this.unitService = unitService;
    }

    [HttpGet("{clientId}/units")]
    public async Task<IActionResult> GetUnitByClientId(int clientId)
    {
        var clientExist = await this.clientService.FindClientById(clientId);

        if (clientExist == null)
        {
            return this.NotFound("Client Not found");
        }

        var unitsId = await this.service.GetUnitByClientId(clientId);

        return this.Ok(unitsId);
    }

    [HttpPost]

    public async Task<IActionResult> AssociateClientUnit([FromBody] PropertyDTO property)
    {
        var unitExist = await this.unitService.GetUnitById(property.UnitId);
        var clientExist = await this.clientService.FindClientById(property.ClientId);

        if (unitExist == null || clientExist == null)
        {
            return this.NotFound("Not found");
        }

        var result = await this.service.SaveProperty(property);

        if (result > 0)
        {
            var response = new
            {
                message = "Unit related with client with success",
            };
            return this.Created(nameof(this.AssociateClientUnit), response);
        }
        else
        {
            return this.BadRequest("Failed to relate unit with client");
        }
    }
}
