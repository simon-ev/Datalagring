

namespace ProjectManager.Models;

public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    public string Name { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
}
