namespace Ovning_9.Models;

public class ProductViewModel
{
    public string Name { get; }
    public int Price { get; }
    public int Count { get; }
    public double InventoryValue => Price * Count;

    public ProductViewModel(string name, int price, int count)
    {
        Name = name;
        Price = price;
        Count = count;
    }
}
