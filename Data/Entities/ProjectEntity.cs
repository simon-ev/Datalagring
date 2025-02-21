

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public string CustomerName { get; set; } = null!;
    public CustomerEntity Customer { get; set; } = null!;

    public int Status { get; set; } 
    //public StatusTypeEntity Status { get; set; } = null!;

    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int TotalCost { get; set; }
    public string Service { get; set; } = null!;

    public string ProjectManager { get; set; } = null!;



}