
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }
    public int ProjectManager { get; set; }

    public int CustomerId { get; set; }

    public int StatusId { get; set; }

    public int UserId { get; set; }

    public int Service { get; set; }
    public int TotalCost { get; set; }

}
