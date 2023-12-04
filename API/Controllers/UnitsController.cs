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
    private readonly UnitsService _service;
    private readonly ClientService _clientsService;
    public UnitsController(UnitsService service, ClientService clientService)
    {
        _service = service;
        _clientsService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUnits()
    {
        var units = await _service.GetAllUnits();
        return Ok(units);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUnit([FromBody] Units unit)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdUnit = await _service.CreateUnit(unit);

        return CreatedAtAction(nameof(CreateUnit), new { id = createdUnit.Id }, createdUnit);
    }

    [HttpPost("{id}/rent-unit")]
    public async Task<IActionResult> RentUnit(int id, [FromBody] UpdateTenantInfoDTO TenantClient)
    {
        var unitExist = await _service.GetUnitById(id);
        var clientExist = await _clientsService.FindClientById(TenantClient.TenantClientId);

        if (unitExist == null || clientExist == null)
        {
            return NotFound("Not found");
        }

        unitExist.TenantStartedAt = DateTime.ParseExact(TenantClient.TenantStartedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        unitExist.TenantFinishedAt = DateTime.ParseExact(TenantClient.TenantFinishedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        unitExist.TenantClientId = TenantClient.TenantClientId;

        var rentUnit = await _service.RentUnit(unitExist);

        if (rentUnit > 0)
        {
            //That could be a DTO
            return Created($"Unit {id} Rented with success", null);
        }
        else
        {
            return BadRequest("Failed to create Maintenance");
        }


    }

}
