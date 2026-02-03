using SimpleStore.Models;
using Microsoft.EntityFrameworkCore;
namespace SimpleStore.Data;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products {get ; set;}
}