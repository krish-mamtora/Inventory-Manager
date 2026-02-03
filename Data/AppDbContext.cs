using SimpleStore.Models;

namespace SimpleStore.Data;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(option)
    {
        
    }
    public DbSet<Product> Products {get ; set;}
}