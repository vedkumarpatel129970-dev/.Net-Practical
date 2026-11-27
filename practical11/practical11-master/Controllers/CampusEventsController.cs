using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical11.Data;
using practical11.Models;

namespace practical11.Controllers;

public class CampusEventsController(CampusDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var events = await context.CampusEvents
            .AsNoTracking()
            .OrderBy(e => e.EventDate)
            .ToListAsync();

        return View(events);
    }

    public IActionResult Create() => View(new CampusEvent());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CampusEvent campusEvent)
    {
        if (!ModelState.IsValid)
        {
            return View(campusEvent);
        }

        context.CampusEvents.Add(campusEvent);
        await context.SaveChangesAsync();

        TempData["Success"] = "Campus event added successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var campusEvent = await context.CampusEvents.FindAsync(id);
        return campusEvent is null ? NotFound() : View(campusEvent);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CampusEvent campusEvent)
    {
        if (id != campusEvent.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(campusEvent);
        }

        var existing = await context.CampusEvents.FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.Title = campusEvent.Title;
        existing.Location = campusEvent.Location;
        existing.EventDate = campusEvent.EventDate;
        existing.Description = campusEvent.Description;

        await context.SaveChangesAsync();

        TempData["Success"] = "Campus event updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var campusEvent = await context.CampusEvents
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        return campusEvent is null ? NotFound() : View(campusEvent);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var campusEvent = await context.CampusEvents.FindAsync(id);
        if (campusEvent is null)
        {
            TempData["Error"] = "Campus event was not found or may have already been deleted.";
            return RedirectToAction(nameof(Index));
        }

        context.CampusEvents.Remove(campusEvent);
        await context.SaveChangesAsync();

        TempData["Success"] = "Campus event deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
