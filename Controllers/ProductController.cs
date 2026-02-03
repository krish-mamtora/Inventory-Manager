using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Models;
using SimpleStore.Services;


namespace SimpleStore.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        ViewBag.Total = _service.getTotalProducts();
        return View(_service.GetProducts());
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }       
        _service.AddProduct(product);
        return RedirectToAction("Index"); 
    }
}