using Microsoft.EntityFrameworkCore;
using PizzaApplication.Models;
using PizzaApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepo<int, Pizza>, PizzaRepo>();
builder.Services.AddDbContext<PizzaShopContext>(options =>
{
    options.UseSqlServer(ConfigurationManager)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.Run();
