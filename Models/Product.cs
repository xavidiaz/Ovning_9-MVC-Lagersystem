namespace Ovning_9.Models;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public int Price { get; }
    public DateTime Orderdate { get; }
    public string Category { get; }
    public string Shelf { get; }
    public int Count { get; }
    public string Description { get; }

    public Product(
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
        Id = id;
        Name = name;
        Price = price;
        Orderdate = orderdate;
        Category = category;
        Shelf = shelf;
        Count = count;
        Description = description;
    }
}
