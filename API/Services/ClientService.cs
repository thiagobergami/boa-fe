// <copyright file="ClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ClientService
{
    private readonly DataContext context;

    public ClientService(DataContext context)
    {
        this.context = context;
    }

    public async Task<ActionResult<IEnumerable<Clients>>> ListAllClients()
    {
        return await this.context.Clients.ToListAsync();
    }

    public async Task<Clients> FindClientById(int id)
    {
        var client = await this.context.Clients.FindAsync(id);
        return client;
    }

    public async Task<int> CreateClient(Clients client)
    {
        this.context.Clients.Add(client);
        return await this.context.SaveChangesAsync();
    }

    public async Task<int> UpdateClient(Clients updatedClient)
    {
        updatedClient.UpdatedAt = DateTime.UtcNow;
        this.context.Entry(updatedClient).State = EntityState.Modified;
        return await this.context.SaveChangesAsync();
    }

    public async Task<int> DeleteClient(Clients client)
    {
        this.context.Clients.Remove(client);
        return await this.context.SaveChangesAsync();
    }
}
