using Microsoft.AspNetCore.Http.HttpResults;
using SimpleStore.Models;
using SimpleStore.Repositories;

namespace SimpleStore.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService (IProductRepository repo)
    {
        _repo = repo;
    }
    public List<Product> GetProducts()
    {
        return _repo.GetAll();
    }
    public void AddProduct(Product product)
    {
        if(product.Price <= 0)
        {
            throw new Exception ("price must be positive");
        }
        _repo.Add(product);
    }

    public int getTotalProducts()
    {
        return _repo.GetTotalCount();
    }
    public void DeleteProduct(int id)
    {
        var product = _repo.GetById(id);
        if (product == null)
        {
            throw new InvalidOperationException($"Product with id {id} not found.");
            // return NotFound();
        }
        _repo.DeleteProduct(id);
    }   
    public Product? GetById(int id)
    {
        var product = _repo.GetById(id);
        if(product==null)
        {
            throw new InvalidOperationException($"Product with id {id} not found.");
        }
        return product;
    }
} 