using API.Data;
using API.Entities;

namespace API.Services;

public class MaintenancesService
{
    private readonly DataContext _context;
    public MaintenancesService(DataContext context)
    {
        _context = context;
    }

    public async Task<Maintenances> GetMaintenanceById(int id)
    {
        return await _context.Maintenances.FindAsync(id);
    }

    public async Task<int> CreateMaintenance(Maintenances maintenance)
    {
        if (maintenance == null)
        {
            throw new ArgumentNullException(nameof(maintenance));
        }

        maintenance.CreatedAt = DateTime.UtcNow;
        maintenance.UpdatedAt = DateTime.UtcNow;

        _context.Maintenances.Add(maintenance);
        return await _context.SaveChangesAsync();
    }
}
