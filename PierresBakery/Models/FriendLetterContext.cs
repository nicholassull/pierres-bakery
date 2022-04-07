using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresBakery.Models
{
  public class PierresBakeryContext : IdentityDbContext<ApplicationUser>
  {
    //Change to class the DB is dealing with
    // public DbSet<Item> Item { get; set; }
    // public DbSet<Category> Category { get; set; }
    // public DbSet<CategoryItem> CategoryItem { get; set; }
    public PierresBakeryContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}