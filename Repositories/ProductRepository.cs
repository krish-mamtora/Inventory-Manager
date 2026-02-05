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
        Console.WriteLine("Product added in DB!");
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public int GetTotalCount()
    {
        using SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        SqlCommand query = new SqlCommand("select count(*) from Products", con); 
        con.Open();
        return (int)query.ExecuteScalar();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product!=null)
        {
              _context.Products.Remove(product);
                 _context.SaveChanges();
        }
        return;
    }
    public Product? GetById(int id)
    {
       return  _context.Products.FirstOrDefault(p => p.Id == id);
    }
}
