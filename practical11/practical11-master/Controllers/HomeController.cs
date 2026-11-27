using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical11.Data;
using practical11.Models;

namespace practical11.Controllers;

public class HomeController(CampusDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var today = DateTime.Today;

        var viewModel = new DashboardViewModel
        {
            TotalRequests = await context.ServiceRequests.CountAsync(),
            PendingRequests = await context.ServiceRequests.CountAsync(r => r.Status == "Pending"),
            InProgressRequests = await context.ServiceRequests.CountAsync(r => r.Status == "In Progress"),
            ResolvedRequests = await context.ServiceRequests.CountAsync(r => r.Status == "Resolved"),
            RecentRequests = await context.ServiceRequests
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToListAsync(),
            UpcomingEvents = await context.CampusEvents
                .AsNoTracking()
                .Where(e => e.EventDate >= today)
                .OrderBy(e => e.EventDate)
                .Take(5)
                .ToListAsync()
        };

        return View(viewModel);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
