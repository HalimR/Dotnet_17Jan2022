using Microsoft.EntityFrameworkCore;
using T3ProjectApplication.Services;
using T3ProjectApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepo<int, User>, UserEFRepo>();
string conn = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<T3ShopContext>(options =>
{
    options.UseSqlServer(conn);
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
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
