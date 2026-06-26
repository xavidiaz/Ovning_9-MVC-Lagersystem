# Övning 9: MVC - Lagersystem (Storage)

ASP.NET Core MVC app för lagerhantering av produkter.

## Branch-strategi

| Branch             | Innehåll                           |
| ------------------ | ---------------------------------- |
| `main`             | Stabil kod, mergas efter varje fas |
| `fas-1/controller` | Hårdkodad controller utan vyer     |
| `fas-2/views`      | Razor Views + ViewModel            |
| `fas-3/model`      | EF Core, databas, riktig data      |

## Fas 1 — Controller (hårdkodad data, inga vyer)

- [x] Skapa MVC-projekt: `dotnet new mvc`
- [x] Skapa `Controllers/ProductsController.cs`
- [ ] Hårdkoda en lista av produkter direkt i controllern (anonyma objekt eller dictionary)
- [ ] `Index` → returnerar `Content()` eller `Json()` med alla produkter
- [ ] `Details(int id)` → returnerar en produkt som text/JSON
- [ ] `Create` (POST) → tar emot query params, lägger till i listan, returnerar bekräftelse
- [ ] Uppdatera routing i `Program.cs` → default controller = Products
- [ ] Testa alla endpoints i webbläsaren / `curl`

## Fas 2 — Views (controller + Razor, fortfarande hårdkodad data)

- [ ] Ersätt `Content()`/`Json()` med `return View(products)` i controllern
- [ ] Skapa Razor Views under `Views/Products/`:
  - [ ] `Index.cshtml` — produktlista med `@model`
  - [ ] `Details.cshtml`
  - [ ] `Create.cshtml` — formulär med Form Tag Helpers
  - [ ] `Edit.cshtml`
  - [ ] `Delete.cshtml`
- [ ] Lägg till navigation i `_Layout.cshtml` → Products/Index
- [ ] Skapa `ProductViewModel` (`Name`, `Price`, `Count`, `InventoryValue`)
- [ ] Skapa action som mappar hårdkodad data → `ProductViewModel` (Price × Count)
- [ ] Skapa vy för inventory overview
- [ ] Skapa sökformulär för kategorifiltrering (fortfarande mot hårdkodad lista)

## Fas 3 — Model (EF Core ersätter hårdkodad data)

- [ ] Skapa `Models/Product.cs` med auto-properties:
  - `int Id`, `string Name`, `int Price`, `DateTime Orderdate`, `string Category`, `string Shelf`, `int Count`, `string Description`
- [ ] Lägg till Data Annotations (`[Range]`, `[Required]`, `[DataType(DataType.Date)]`)
- [ ] Skapa `Data/StorageContext.cs` (ärver `DbContext`, `DbSet<Product> Product`)
- [ ] Registrera `StorageContext` i `Program.cs` med `AddDbContext`
- [ ] Konfigurera connection string i `appsettings.json`
- [ ] `dotnet ef migrations add Init` → `dotnet ef database update`
- [ ] Seeda testdata
- [ ] Injicera `StorageContext` i `ProductsController` via konstruktorn
- [ ] Ersätt hårdkodad lista med `_context.Product` i alla actions
- [ ] Verifiera att alla vyer fungerar med riktig data
- [ ] **Extra:** Dropdown-meny med kategorier från databasen (`IEnumerable<SelectListItem>`)
- [ ] **Extra:** Kombinerad filtrering på kategori + produktnamn
