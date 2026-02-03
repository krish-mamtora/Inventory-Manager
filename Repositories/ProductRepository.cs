using Microsoft.EntityFrameworkCore;
using SimpleStore.Models;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using SimpleStore.Data;
namespace SimpleStore.Repositories;

class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public ProductRepository(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }


    public void Add(Product product)
    {
        _context.Products.AddAsync(product);
        _context.SaveChangesAsync();
    }

    public int GetTotalCount()
    {
        using SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        SqlCommand query = new SqlCommand("select count(*) from Products", con); 
        con.Open();
        return (int)query.ExecuteScalar();
    }

}
