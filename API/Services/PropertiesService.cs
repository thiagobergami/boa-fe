// <copyright file="PropertiesService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class PropertiesService
{
    private readonly DataContext context;

    public PropertiesService(DataContext context)
    {
        this.context = context;
    }

    public async Task<List<int>> GetUnitByClientId(int clientId)
    {
        var units = await this.context.Properties
            .Where(p => p.ClientId == clientId)
            .Select(p => p.UnitId)
            .ToListAsync();

        return units;
    }

    public async Task<int> SaveProperty(PropertyDTO property)
    {
        try
        {
            var properties = new Properties
            {
                ClientId = property.ClientId,
                UnitId = property.UnitId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            this.context.Properties.Add(properties);
            return await this.context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception (log it, rethrow, etc.)
            Console.WriteLine($"Error saving property: {ex.Message}");
            throw;
        }
    }
}
