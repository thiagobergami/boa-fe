using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")] // to access this contorller will be /api/users
public class ClientsController : ControllerBase
{   
    private readonly DataContext _context;
    public ClientsController(DataContext context){
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
    {
        var clients = await _context.Clients.ToListAsync();

        return clients;
    }
}
