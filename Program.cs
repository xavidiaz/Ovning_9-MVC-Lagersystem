using Microsoft.EntityFrameworkCore;
using Ovning_9.Data;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<StorageContext>(options =>
    options.UseSqlite("Data Source=storage.db")
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(name: "default", pattern: "{controller=Products}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
