# Övning 9: MVC - Lagersystem (Storage)

ASP.NET Core MVC app för lagerhantering av produkter.

## Branch-strategi

| Branch             | Innehåll                           |
| ------------------ | ---------------------------------- |
| `main`             | Stabil kod, mergas efter varje fas |
| `fas-1/controller` | Hårdkodad controller utan vyer ✅  |
| `fas-2/views`      | Razor Views + ViewModel            |
| `fas-3/model`      | EF Core, databas, riktig data      |

## Fas 1 — Controller (hårdkodad data, inga vyer) ✅

- [x] Skapa MVC-projekt: `dotnet new mvc`
- [x] Skapa `Controllers/ProductsController.cs`
- [x] Hårdkoda en lista av produkter direkt i controllern (record + List)
- [x] `Index` → returnerar `Json()` med alla produkter
- [x] `Details(int id)` → returnerar en produkt som JSON
- [x] `Create` → tar emot query params, lägger till i listan, returnerar JSON
- [x] Uppdatera routing i `Program.cs` → default controller = Products
- [x] Testa alla endpoints i webbläsaren / `curl`

## Fas 2 — Views (controller + Razor, fortfarande hårdkodad data)

- [x] Ersätt `Json()` med `return View(products)` i controllern
- [x] Skapa Razor Views under `Views/Products/`:
  - [x] `Index.cshtml` — produktlista med `@model`
  - [x] `Details.cshtml`
  - [x] `Create.cshtml` — formulär med Form Tag Helpers
  - [x] `Edit.cshtml`
  - [x] `Delete.cshtml`
- [x] Lägg till navigation i `_Layout.cshtml` → Products/Index
- [x] Skapa `ProductViewModel` (`Name`, `Price`, `Count`, `InventoryValue`)
- [x] Skapa action som mappar hårdkodad data → `ProductViewModel` (Price × Count)
- [x] Skapa vy för inventory overview
- [x] Skapa sökformulär för kategorifiltrering (fortfarande mot hårdkodad lista)

## Fas 3 — Model (EF Core ersätter hårdkodad data)

- [x] Skapa `Models/Product.cs` med auto-properties:
  - `int Id`, `string Name`, `int Price`, `DateTime Orderdate`, `string Category`, `string Shelf`, `int Count`, `string Description`
- [x] Lägg till Data Annotations (`[Range]`, `[Required]`, `[DataType(DataType.Date)]`)
- [x] Skapa `Data/StorageContext.cs` (ärver `DbContext`, `DbSet<Product> Product`)
- [x] Registrera `StorageContext` i `Program.cs` med `AddDbContext`
- [x] Konfigurera connection string i `appsettings.json`
- [x] `dotnet ef migrations add Init` → `dotnet ef database update`
- [x] Seeda testdata
- [x] Injicera `StorageContext` i `ProductsController` via konstruktorn
- [x] Ersätt hårdkodad lista med `_context.Product` i alla actions
- [ ] Verifiera att alla vyer fungerar med riktig data
- [ ] **Extra:** Dropdown-meny med kategorier från databasen (`IEnumerable<SelectListItem>`)
- [ ] **Extra:** Kombinerad filtrering på kategori + produktnamn
