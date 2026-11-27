using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical11.Data;
using practical11.Models;

namespace practical11.Controllers;

public class ServiceRequestsController(CampusDbContext context) : Controller
{
    private static readonly string[] AllowedStatuses = ["Pending", "In Progress", "Resolved"];

    public async Task<IActionResult> Index(string? status, string? search)
    {
        var requests = context.ServiceRequests.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            requests = requests.Where(x => x.Status == status);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim();
            requests = requests.Where(x =>
                x.StudentName.Contains(term) ||
                x.Issue.Contains(term) ||
                x.Department.Contains(term));
        }

        ViewBag.Status = status;
        ViewBag.Search = search;
        ViewBag.Statuses = AllowedStatuses;

        return View(await requests.OrderByDescending(x => x.CreatedAt).ToListAsync());
    }

    public IActionResult Create()
    {
        ViewBag.Statuses = AllowedStatuses;
        return View(new ServiceRequest());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceRequest request)
    {
        if (!AllowedStatuses.Contains(request.Status))
        {
            ModelState.AddModelError(nameof(ServiceRequest.Status), "Please select a valid status.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Statuses = AllowedStatuses;
            return View(request);
        }

        request.CreatedAt = DateTime.Now;
        context.ServiceRequests.Add(request);
        await context.SaveChangesAsync();

        TempData["Success"] = "Service request submitted successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var request = await context.ServiceRequests
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        return request is null ? NotFound() : View(request);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request is null)
        {
            return NotFound();
        }

        ViewBag.Statuses = AllowedStatuses;
        return View(request);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServiceRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        if (!AllowedStatuses.Contains(request.Status))
        {
            ModelState.AddModelError(nameof(ServiceRequest.Status), "Status must be Pending, In Progress, or Resolved.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Statuses = AllowedStatuses;
            return View(request);
        }

        var existing = await context.ServiceRequests.FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.StudentName = request.StudentName;
        existing.Department = request.Department;
        existing.Issue = request.Issue;
        existing.Description = request.Description;
        existing.Status = request.Status;

        await context.SaveChangesAsync();

        TempData["Success"] = "Service request updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var request = await context.ServiceRequests
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        return request is null ? NotFound() : View(request);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request is null)
        {
            TempData["Error"] = "Service request was not found or may have already been deleted.";
            return RedirectToAction(nameof(Index));
        }

        context.ServiceRequests.Remove(request);
        await context.SaveChangesAsync();

        TempData["Success"] = "Service request deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
