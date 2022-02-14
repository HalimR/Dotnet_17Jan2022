using Microsoft.EntityFrameworkCore;
using SampleMVCApplication.Models;
using SampleMVCApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string strCon = builder.Configuration.GetConnectionString("myConn");
builder.Services.AddDbContext<ShopContext>(opts =>
{
    opts.UseSqlServer(strCon); //depends on the db database u use, this case using sqlserver
});

//If using VS 2019 with .Net 5:
//services.AddDbContext<ShopContext>(opts =>
//{
//    opts.UseSqlServer(Configuration["ConnectionStrings:myCon"]);
//});

//Injecting the service
builder.Services.AddScoped<IRepo<int,Customer>, CustomerRepo>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
