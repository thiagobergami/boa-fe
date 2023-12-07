// <copyright file="UnitsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class UnitsService
{
    private readonly DataContext context;

    public UnitsService(DataContext context)
    {
        this.context = context;
    }

    public async Task<List<UnitsDTO>> GetAllUnits()
    {
        var units = await this.context.Units.ToListAsync();
        var unitsDTO = this.MapToDto(units);
        return unitsDTO;
    }

    public async Task<Units> GetUnitById(int id)
    {
        return await this.context.Units.FindAsync(id);
    }

    public async Task<Units> CreateUnit(Units unit)
    {
        this.context.Units.Add(unit);
        await this.context.SaveChangesAsync();
        return unit;
    }

    public async Task<int> RentUnit(Units unit)
    {
        this.context.Entry(unit).State = EntityState.Modified;
        return await this.context.SaveChangesAsync();
    }

    public List<UnitsDTO> MapToDto(List<Units> units)
    {
        return units.Select(unit => new UnitsDTO
        {
            Id = unit.Id,
            Name = unit.Name,
            Address = unit.Adress,
            TenantClientId = unit.TenantClientId,
            TenantStartedAt = unit.TenantStartedAt,
            TenantFinishedAt = unit.TenantFinishedAt,
            Maintenances = this.GetMaintenancesByUnitId(unit.Id),
            CondominiumId = unit.CondominiumId,
            Condominium = unit.Condominium,
        }).ToList();
    }

    public List<MaintenanceUnitDTO> GetMaintenancesByUnitId(int unitId)
    {
        var maintenance = this.context.Maintenances
            .Where(main => main.UnitID == unitId)
            .Select(main => new MaintenanceUnitDTO
            {
                Id = main.Id,
                ProblemDescription = main.ProblemDescription,
                IsSolved = main.IsSolved,
                UpdatedAt = main.UpdatedAt,
                CreatedAt = main.CreatedAt,
            })
            .ToList();

        return maintenance;
    }
}
