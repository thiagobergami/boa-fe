using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly PropertiesService _service;
    private readonly ClientService _clientService;
    private readonly UnitsService _unitService;

    public PropertiesController(PropertiesService service, ClientService clientService, UnitsService unitService)
    {
        _service = service;
        _clientService = clientService;
        _unitService = unitService;
    }

    [HttpGet("{clientId}/units")]
    public async Task<IActionResult> GetUnitByClientId(int clientId)
    {
        var clientExist = await _clientService.FindClientById(clientId);

        if (clientExist == null)
        {
            return NotFound("Client Not found");
        }

        var unitsId = await _service.GetUnitByClientId(clientId);

        return Ok(unitsId);
    }

    [HttpPost]

    public async Task<IActionResult> AssociateClientUnit([FromBody] PropertyDTO property)
    {
        var unitExist = await _unitService.GetUnitById(property.UnitId);
        var clientExist = await _clientService.FindClientById(property.ClientId);

        if (unitExist == null || clientExist == null)
        {
            return NotFound("Not found");
        }

        var result = await _service.SaveProperty(property);

        if (result > 0)
        {
            var response = new
            {
                message = "Unit related with client with success"
            };
            return Created(nameof(AssociateClientUnit), response);
        }
        else
        {
            return BadRequest("Failed to relate unit with client");
        }
    }
}
