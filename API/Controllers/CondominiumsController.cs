using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CondominiumsController : ControllerBase
{
    private readonly CondominiumsService _service;

    public CondominiumsController(CondominiumsService service){
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Condominiums Condom)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateCondominium(Condom);

        if (result > 0)
        {
            //That could be a DTO
            var response = new
            {
                message = "Client created successfully",
                condominium = Condom,
            };
            return Created(nameof(Create), response);
        }
        else
        {
            return BadRequest("Failed to create client");
        }        
    }
}
