using Microsoft.AspNetCore.Mvc;

namespace Ovning_9.Controllers;

public class ProductsController : Controller
{
    private List<object> products = new()
    {
        new
        {
            Id = 1,
            Name = "Keyboard",
            Price = 899,
            Orderdate = new DateTime(2024, 3, 15),
            Category = "Peripherals",
            Shelf = "A1",
            Count = 45,
            Description = "Mechanical RGB keyboard",
        },
        new
        {
            Id = 2,
            Name = "Monitor",
            Price = 3499,
            Orderdate = new DateTime(2024, 5, 20),
            Category = "Displays",
            Shelf = "B3",
            Count = 12,
            Description = "27 inch 4K IPS",
        },
        new
        {
            Id = 3,
            Name = "Mouse",
            Price = 549,
            Orderdate = new DateTime(2024, 7, 1),
            Category = "Peripherals",
            Shelf = "A2",
            Count = 60,
            Description = "Ergonomic wireless mouse",
        },
        new
        {
            Id = 4,
            Name = "Headset",
            Price = 1299,
            Orderdate = new DateTime(2024, 8, 10),
            Category = "Audio",
            Shelf = "C1",
            Count = 25,
            Description = "Noise cancelling USB headset",
        },
    };

    public IActionResult Index()
    {
        return Json(products);
    }
}
