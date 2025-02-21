
namespace Data.Models;

public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string ProjectManager { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = null!;
    public string Service { get; set; } = null!;
    public int TotalCost { get; set; }
}
