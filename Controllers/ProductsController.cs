using Microsoft.AspNetCore.Mvc;
using Ovning_9.Models;

namespace Ovning_9.Controllers;

public class ProductsController : Controller
{
    private static List<Product> _products = new()
    {
        new Product(
            1,
            "Keyboard",
            899,
            new DateTime(2024, 3, 15),
            "Peripherals",
            "A1",
            45,
            "Mechanical RGB keyboard"
        ),
        new Product(
            2,
            "Monitor",
            3499,
            new DateTime(2024, 5, 20),
            "Displays",
            "B3",
            12,
            "27 inch 4K IPS"
        ),
        new Product(
            3,
            "Mouse",
            549,
            new DateTime(2024, 7, 1),
            "Peripherals",
            "A2",
            60,
            "Ergonomic wireless mouse"
        ),
        new Product(
            4,
            "Headset",
            1299,
            new DateTime(2024, 8, 10),
            "Audio",
            "C1",
            25,
            "Noise cancelling USB headset"
        ),
    };

    public IActionResult Index()
    {
        return View(_products);
    }

    public IActionResult Inventory()
    {
        var products = _products.Select(p => new ProductViewModel(p.Name, p.Price, p.Count));
        return View(products);
    }

    public IActionResult Search(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return View("Index", _products);
        }
        var products = _products.Where(p =>
            p.Category.Contains(category, StringComparison.OrdinalIgnoreCase)
        );
        return View("Index", products);
    }

    public IActionResult Details(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
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
        var product = new Product(id, name, price, orderdate, category, shelf, count, description);
        _products.Add(product);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
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
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing == null)
        {
            return NotFound();
        }
        _products.Remove(existing);
        _products.Add(new Product(id, name, price, orderdate, category, shelf, count, description));
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return RedirectToAction("Index");
    }
}
