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
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        Console.WriteLine("Post Creating ..");
        if (!ModelState.IsValid)
        {
             Console.WriteLine("ModelState Invalid");
            return View(product);
        }
        try
        {
            _service.AddProduct(product);
            Console.WriteLine("Post Created");
            return RedirectToAction("Index");
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return View(product);
        }
        
    }
    [HttpGet("/Product/{id:int}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Please enter a valid Id.");
        }  Console.WriteLine("reached");
        var product = _service.GetById(id);
        if (product == null)
        {
            return NotFound($"Product with Id {id} not found.");
        }
        return Ok(product);
    }

    [HttpDelete("/Product/{id:int}")]
    [ValidateAntiForgeryToken]

    public IActionResult DeleteProduct(int id)
    {
         _service.DeleteProduct(id);
            return Ok();
    }

}