using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical11.Data;

namespace practical11.Controllers;

[ApiController]
[Route("api")]
public class ApiController(CampusDbContext context) : ControllerBase
{
    [HttpGet("requests")]
    public async Task<IActionResult> GetRequests()
    {
        var requests = await context.ServiceRequests
            .AsNoTracking()
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        return Ok(requests);
    }

    [HttpGet("requests/{id:int}")]
    public async Task<IActionResult> GetRequestById(int id)
    {
        var request = await context.ServiceRequests
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        if (request is null)
        {
            return NotFound(new { message = $"Service request with ID {id} was not found." });
        }

        return Ok(request);
    }

    [HttpGet("events")]
    public async Task<IActionResult> GetEvents()
    {
        var events = await context.CampusEvents
            .AsNoTracking()
            .OrderBy(e => e.EventDate)
            .ToListAsync();

        return Ok(events);
    }
}
