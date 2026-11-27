namespace practical11.Models;

public class DashboardViewModel
{
    public int TotalRequests { get; set; }
    public int PendingRequests { get; set; }
    public int InProgressRequests { get; set; }
    public int ResolvedRequests { get; set; }
    public List<ServiceRequest> RecentRequests { get; set; } = [];
    public List<CampusEvent> UpcomingEvents { get; set; } = [];
}
