using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")] // to access this contorller will be /api/users
public class ClientsController : ControllerBase
{
    private readonly ClientService _service;
    public ClientsController(ClientService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
    {
        return Ok(await _service.ListAllClients());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Clients>> GetClient(int id)
    {
        var clientExists = await _service.FindClientById(id);

        if (clientExists == null)
        {
            return NotFound("Client not found");
        }

        return Ok(clientExists);

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Clients client)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateClient(client);

        if (result > 0)
        {
            //That could be a DTO
            var response = new
            {
                message = "Client created successfully",
                client
            };
            return Created(nameof(Create), response);
        }
        else
        {
            return BadRequest("Failed to create client");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Clients client)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var clientThatAlreadyExists = await _service.FindClientById(id);

        if (clientThatAlreadyExists == null)
        {
            return NotFound("Client not found");
        }

        clientThatAlreadyExists.Name = client.Name;
        clientThatAlreadyExists.Age = client.Age;
        clientThatAlreadyExists.Email = client.Email;
        clientThatAlreadyExists.RentUnits = client.RentUnits;

        var result = await _service.UpdateClient(clientThatAlreadyExists);

        if (result > 0)
        {
            //That could be a DTO
            var response = new
            {
                message = "Client updated successfully",
                client
            };
            return CreatedAtAction(nameof(Update), new { id = clientThatAlreadyExists.Id }, response);
        }
        else
        {
            return BadRequest("Failed to update client");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var clientToDelete = await _service.FindClientById(id);

        if (clientToDelete == null)
        {
            return NotFound("Client not found");
        }

        var result = await _service.DeleteClient(clientToDelete);

        if (result > 0)
        {   
            //That could be a DTO
            var response = new
            {
                message = "Client deleted successfully",
                clientId = id
            };

            return Ok(response);
        }
        else
        {
            return BadRequest("Failed to delete client");
        }
    }
}
