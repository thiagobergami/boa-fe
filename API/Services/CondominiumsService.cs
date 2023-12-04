using API.Data;
using API.DTO;
using API.Entities;

namespace API.Services;

public class CondominiumsService
{
    private readonly DataContext _context;

    public CondominiumsService(DataContext context)
    {
        _context = context;
    }

    public async Task<int> CreateCondominium(Condominiums condominium)
    {
        _context.Condominiums.Add(condominium);
        return await _context.SaveChangesAsync();
    }

    public async Task<CondominiumDTO> GetCondominiumsById(int id)
    {
        var condominium = await _context.Condominiums.FindAsync(id);
        var condominiumDTO = new CondominiumDTO{
            Id = condominium.Id,
            Name = condominium.Name,
            Units = GetUnitsByCondominumId(condominium.Id)
        };

        return condominiumDTO;
    }

    public async Task<bool> AssociateUnitsWithCondominium(int condominiumId, List<int> unitIds)
    {
        try
        {
            foreach (var unitId in unitIds)
            {   
                var unit = await _context.Units.FindAsync(unitId);

                if (unit == null)
                {                    
                    throw new InvalidOperationException($"Unit with ID {unitId} not found.");
                }

                unit.CondominiumId = condominiumId;
            }            
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {   
            //Jogar esse ex em alguma ferramenta de Log
            return false; 
        }
    }

    public List<CondominumUnitDTO> GetUnitsByCondominumId(int condominiumId){
        var units = _context.Units
            .Where(unit => unit.CondominiumId == condominiumId)
            .Select(unit => new CondominumUnitDTO{
                Id = unit.Id,
                Name = unit.Name,
                Address = unit.Adress,
            }).ToList();
        
        return units;
    }
}
