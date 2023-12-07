// <copyright file="MaintenancesService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Data;
using API.Entities;

namespace API.Services;

public class MaintenancesService
{
    private readonly DataContext context;

    public MaintenancesService(DataContext context)
    {
        this.context = context;
    }

    public async Task<Maintenances> GetMaintenanceById(int id)
    {
        return await this.context.Maintenances.FindAsync(id);
    }

    public async Task<int> CreateMaintenance(Maintenances maintenance)
    {
        if (maintenance == null)
        {
            throw new ArgumentNullException(nameof(maintenance));
        }

        maintenance.CreatedAt = DateTime.UtcNow;
        maintenance.UpdatedAt = DateTime.UtcNow;

        this.context.Maintenances.Add(maintenance);
        return await this.context.SaveChangesAsync();
    }
}
