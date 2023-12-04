using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class UnitsService
{
    private readonly DataContext _context;
    public UnitsService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<UnitsDTO>> GetAllUnits()
    {   
        var units = await _context.Units.ToListAsync();
        var unitsDTO = MapToDto(units);
        return unitsDTO;
    }

    public async Task<Units> GetUnitById(int id)
    {
        return await _context.Units.FindAsync(id);
    }

    public async Task<Units> CreateUnit(Units unit)
    {
        _context.Units.Add(unit);
        await _context.SaveChangesAsync();
        return unit;
    }

    public async Task<int> RentUnit(Units unit)
    {   
        _context.Entry(unit).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public List<UnitsDTO> MapToDto(List<Units> units){
        return units.Select(unit => new UnitsDTO{
            Id = unit.Id,
            Name = unit.Name,
            Address = unit.Adress,
            TenantClientId = unit.TenantClientId,
            TenantStartedAt = unit.TenantStartedAt,
            TenantFinishedAt = unit.TenantFinishedAt,
            Maintenances = GetMaintenancesByUnitId(unit.Id),
            CondominiumId = unit.CondominiumId,
            Condominium = unit.Condominium            
        }).ToList();
    }

    public List<MaintenanceUnitDTO> GetMaintenancesByUnitId(int unitId){
        var maintenance = _context.Maintenances
            .Where(main => main.UnitID == unitId)
            .Select(main => new MaintenanceUnitDTO{
                Id = main.Id,
                ProblemDescription = main.ProblemDescription,
                IsSolved = main.IsSolved,
                UpdatedAt = main.UpdatedAt,
                CreatedAt = main.CreatedAt
            })
            .ToList();

        return maintenance;
    }
}
