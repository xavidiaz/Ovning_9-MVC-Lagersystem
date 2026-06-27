using System.ComponentModel.DataAnnotations;

namespace Ovning_9.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100000)]
    public int Price { get; set; }

    [DataType(DataType.Date)]
    public DateTime Orderdate { get; set; }

    [Required]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string Shelf { get; set; } = string.Empty;

    [Range(0, 10000)]
    public int Count { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public Product() { }
}
