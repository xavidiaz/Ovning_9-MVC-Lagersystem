using Microsoft.AspNetCore.Mvc;

namespace Ovning_9.Controllers;

public class ProductsController : Controller
{
    record Product(
        int Id,
        string Name,
        int Price,
        DateTime Orderdate,
        string Category,
        string Shelf,
        int Count,
        string Description
    );

    private List<Product> _products = new()
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
        return Json(_products);
    }

    public IActionResult Details(int id)
    {
        var result = _products.FirstOrDefault(p => p.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Json(result);
    }

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
        var _product = new Product(id, name, price, orderdate, category, shelf, count, description);
        _products.Add(_product);

        return Json(_product);
    }
}
