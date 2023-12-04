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
}
