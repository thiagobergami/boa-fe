using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnitsController : ControllerBase
{
    private readonly UnitsService _service;
    public UnitsController(UnitsService service){
        _service = service;
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

}
