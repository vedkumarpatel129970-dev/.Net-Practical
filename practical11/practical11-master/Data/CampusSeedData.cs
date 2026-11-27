using Microsoft.EntityFrameworkCore;

namespace practical11.Data;

public static class CampusSeedData
{
    /// <summary>
    /// Ensures CampusEvents has initial records if empty without modifying existing ServiceRequests.
    /// </summary>
    public static async Task InitializeAsync(CampusDbContext db)
    {
        if (!await db.CampusEvents.AnyAsync())
        {
            var baseDate = DateTime.Today;
            db.CampusEvents.AddRange(
                new Models.CampusEvent
                {
                    Title = "Tech Innovation Day",
                    Location = "Main Auditorium",
                    EventDate = baseDate.AddDays(3).AddHours(10),
                    Description = "Student project showcase, prototype demonstrations, and technical talks."
                },
                new Models.CampusEvent
                {
                    Title = "Campus Sports Meet",
                    Location = "University Sports Ground",
                    EventDate = baseDate.AddDays(10).AddHours(9),
                    Description = "Inter-department sports activities, track events, and team competitions."
                },
                new Models.CampusEvent
                {
                    Title = "Cloud & .NET Workshop",
                    Location = "Computer Engineering Seminar Hall",
                    EventDate = baseDate.AddDays(15).AddHours(14),
                    Description = "Hands-on workshop on ASP.NET Core MVC, Entity Framework Core, and REST APIs."
                }
            );

            await db.SaveChangesAsync();
        }
    }
}
