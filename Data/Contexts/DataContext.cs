

using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; } 
    public DbSet<ProductEntity> Products { get; set; } 
    public DbSet<ProjectEntity> Projects { get; set; }
    //public DbSet<StatusTypeEntity> StatusTypes { get; set; }



    //// Skrivet av Chatgpt som löser ett problem med statustyper.
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder); 

    //    modelBuilder.Entity<StatusTypeEntity>().HasData(
    //        new StatusTypeEntity { Id = (int)ProjectStatus.NotStarted, StatusName = ProjectStatus.NotStarted.ToString() },
    //        new StatusTypeEntity { Id = (int)ProjectStatus.Active, StatusName = ProjectStatus.Active.ToString() },
    //        new StatusTypeEntity { Id = (int)ProjectStatus.OnHold, StatusName = ProjectStatus.OnHold.ToString() },
    //        new StatusTypeEntity { Id = (int)ProjectStatus.Completed, StatusName = ProjectStatus.Completed.ToString() }
    //    );
    //}

}
