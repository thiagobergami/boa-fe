// <copyright file="CondominiumsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Data;
using API.DTO;
using API.Entities;

namespace API.Services;

public class CondominiumsService
{
    private readonly DataContext context;

    public CondominiumsService(DataContext context)
    {
        this.context = context;
    }

    public async Task<int> CreateCondominium(Condominiums condominium)
    {
        this.context.Condominiums.Add(condominium);
        return await this.context.SaveChangesAsync();
    }

    public async Task<CondominiumDTO> GetCondominiumsById(int id)
    {
        var condominium = await this.context.Condominiums.FindAsync(id);
        var condominiumDTO = new CondominiumDTO
        {
            Id = condominium.Id,
            Name = condominium.Name,
            Units = this.GetUnitsByCondominumId(condominium.Id),
        };

        return condominiumDTO;
    }

    public async Task<bool> AssociateUnitsWithCondominium(int condominiumId, List<int> unitIds)
    {
        try
        {
            foreach (var unitId in unitIds)
            {
                var unit = await this.context.Units.FindAsync(unitId);

                if (unit == null)
                {
                    throw new InvalidOperationException($"Unit with ID {unitId} not found.");
                }

                unit.CondominiumId = condominiumId;
            }

            await this.context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {   
            Console.WriteLine($"Error : {ex.Message}");
            return false;
        }
    }

    public List<CondominumUnitDTO> GetUnitsByCondominumId(int condominiumId)
    {
        var units = this.context.Units
            .Where(unit => unit.CondominiumId == condominiumId)
            .Select(unit => new CondominumUnitDTO
            {
                Id = unit.Id,
                Name = unit.Name,
                Address = unit.Adress,
            }).ToList();

        return units;
    }
}
