using SimpleStore.Models;
namespace SimpleStore.Services;

public interface IProductService
{
    List<Product> GetProducts();
    void AddProduct(Product product);
    int getTotalProducts();
}