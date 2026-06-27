using Microsoft.EntityFrameworkCore;
using Ovning_9.Models;

namespace Ovning_9.Data;

public class StorageContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    public StorageContext(DbContextOptions<StorageContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Product>()
            .HasData(
                new Product
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
                new Product
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
                new Product
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
                new Product
                {
                    Id = 4,
                    Name = "Headset",
                    Price = 1299,
                    Orderdate = new DateTime(2024, 8, 10),
                    Category = "Audio",
                    Shelf = "C1",
                    Count = 25,
                    Description = "Noise cancelling USB headset",
                }
            );
    }
}
