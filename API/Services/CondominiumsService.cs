using API.Data;
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

    public async Task<Condominiums> GetCondominiumsById(int id)
    {
        return await _context.Condominiums.FindAsync(id); ;
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
}
