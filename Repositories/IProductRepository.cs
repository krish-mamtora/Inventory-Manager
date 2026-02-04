
using SimpleStore.Models;
public interface IProductRepository
{
    List<Product> GetAll();
      void Add(Product product);
     int GetTotalCount();
    void DeleteProduct(int id); 
     Product? GetById(int id);
}