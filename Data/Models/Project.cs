
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
    public string ProjectManager { get; set; } = null!;

    public string? CustomerName { get; set; } 

    public int? ProductId { get; set; }

    public string Status { get; set; } = null!;
    public int CustomerId { get; set; }

    public string Service { get; set; } = null!;
    public int TotalCost { get; set; }

}
