using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class PropertiesService
{
    private readonly DataContext _context;

    public PropertiesService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<int>> GetUnitByClientId(int ClientId)
    {
        var units = await _context.Properties
            .Where(p => p.ClientId == ClientId)
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
                UpdatedAt = DateTime.UtcNow
            };

            _context.Properties.Add(properties);
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception (log it, rethrow, etc.)
            Console.WriteLine($"Error saving property: {ex.Message}");
            throw;
        }
    }
}
