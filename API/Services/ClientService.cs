using System.Collections;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ClientService
{
    private readonly DataContext _context;
    public ClientService(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Clients>>> ListAllClients()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Clients> FindClientById(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        return client;
    }

    public async Task<int> CreateClient(Clients client)
    {
        _context.Clients.Add(client);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateClient(Clients updatedClient)
    {
        updatedClient.UpdatedAt = DateTime.UtcNow;
        _context.Entry(updatedClient).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteClient(Clients client)
    {
        _context.Clients.Remove(client);
        return await _context.SaveChangesAsync();
    }
}
