using System.ComponentModel.DataAnnotations;
namespace SimpleStore.Models;
public class Product
{
    public int Id {get ; set;}
[Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = null!;
    public string Category {get ; set;} = null!;
    [Range(1, 5000, ErrorMessage = "Price must be between 1 and 5000")]
    public int Price  {get ; set;}
    public int Quantity  {get ; set;}
}