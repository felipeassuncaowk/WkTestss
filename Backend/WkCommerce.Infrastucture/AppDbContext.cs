using Microsoft.EntityFrameworkCore;
using WkCommerce.Domain.Entity;

namespace WkCommerce.Infrastucture;

public class AppDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}