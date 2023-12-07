// <copyright file="ClientsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // to access this contorller will be /api/users
public class ClientsController : ControllerBase
{
    private readonly ClientService service;

    public ClientsController(ClientService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
    {
        return this.Ok(await this.service.ListAllClients());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Clients>> GetClient(int id)
    {
        var clientExists = await this.service.FindClientById(id);

        if (clientExists == null)
        {
            return this.NotFound("Client not found");
        }

        return this.Ok(clientExists);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Clients client)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var result = await this.service.CreateClient(client);

        if (result > 0)
        {
            // That could be a DTO
            var response = new
            {
                message = "Client created successfully",
                client,
            };
            return this.Created(nameof(this.Create), response);
        }
        else
        {
            return this.BadRequest("Failed to create client");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Clients client)
    {
        if (!this.ModelState.IsValid)
        {
            return this.BadRequest(this.ModelState);
        }

        var clientThatAlreadyExists = await this.service.FindClientById(id);

        if (clientThatAlreadyExists == null)
        {
            return this.NotFound("Client not found");
        }

        clientThatAlreadyExists.Name = client.Name;
        clientThatAlreadyExists.Age = client.Age;
        clientThatAlreadyExists.Email = client.Email;
        clientThatAlreadyExists.RentUnits = client.RentUnits;

        var result = await this.service.UpdateClient(clientThatAlreadyExists);

        if (result > 0)
        {
            // That could be a DTO
            var response = new
            {
                message = "Client updated successfully",
                client,
            };
            return this.CreatedAtAction(nameof(this.Update), new { id = clientThatAlreadyExists.Id }, response);
        }
        else
        {
            return this.BadRequest("Failed to update client");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var clientToDelete = await this.service.FindClientById(id);

        if (clientToDelete == null)
        {
            return this.NotFound("Client not found");
        }

        var result = await this.service.DeleteClient(clientToDelete);

        if (result > 0)
        {
            // That could be a DTO
            var response = new
            {
                message = "Client deleted successfully",
                clientId = id,
            };

            return this.Ok(response);
        }
        else
        {
            return this.BadRequest("Failed to delete client");
        }
    }
}
