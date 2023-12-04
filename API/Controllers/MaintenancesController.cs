using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class MaintenancesController : ControllerBase
{
    private readonly MaintenancesService _service;
    private readonly UnitsService _unitService;
    public MaintenancesController(MaintenancesService service, UnitsService unitService)
    {
        _service = service;
        _unitService = unitService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaintenance(int id)
    {
        var maintenance = await _service.GetMaintenanceById(id);
        if (maintenance == null)
        {
            return NotFound("Maintenance order not found");
        }

        return Ok(maintenance);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Maintenances maintenance)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var unitExist = await _unitService.GetUnitById(maintenance.UnitID);

        if (unitExist == null)
        {
            return NotFound("Unit not found");
        }

        var result = await _service.CreateMaintenance(maintenance);
        if (result > 0)
        {
            //That could be a DTO
            var response = new
            {
                message = "Maintenance created successfully",
                maintenance
            };
            return Created(nameof(Create), response);
        }
        else
        {
            return BadRequest("Failed to create Maintenance");
        }
    }
}
