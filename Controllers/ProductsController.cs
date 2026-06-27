using Microsoft.AspNetCore.Mvc;
using Ovning_9.Data;
using Ovning_9.Models;

namespace Ovning_9.Controllers;

public class ProductsController : Controller
{
    // private static List<Product> _context.Products = new();
    private readonly StorageContext _context;

    public ProductsController(StorageContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Products);
    }

    public IActionResult Inventory()
    {
        var products = _context.Products.Select(p => new ProductViewModel(
            p.Name,
            p.Price,
            p.Count
        ));
        return View(products);
    }

    public IActionResult Search(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return View("Index", _context.Products);
        }
        var products = _context.Products.Where(p =>
            p.Category.ToLower().Contains(category.ToLower())
        );
        return View("Index", products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(
        string name,
        int price,
        DateTime orderdate,
        string category,
        string shelf,
        int count,
        string description
    )
    {
        var product = new Product
        {
            Name = name,
            Price = price,
            Orderdate = orderdate,
            Category = category,
            Shelf = shelf,
            Count = count,
            Description = description,
        };

        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(
        int id,
        string name,
        int price,
        DateTime orderdate,
        string category,
        string shelf,
        int count,
        string description
    )
    {
        var existing = _context.Products.FirstOrDefault(p => p.Id == id);
        if (existing == null)
        {
            return NotFound();
        }
        existing.Name = name;
        existing.Price = price;
        existing.Orderdate = orderdate;
        existing.Category = category;
        existing.Shelf = shelf;
        existing.Count = count;
        existing.Description = description;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
