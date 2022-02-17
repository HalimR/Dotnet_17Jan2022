using FirstWebAPIApplication;
using FirstWebAPIApplication.Models;
using FirstWebAPIApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //to be added along swashbuckler

//DbContext
string strCon = builder.Configuration.GetConnectionString("myConn");
builder.Services.AddDbContext<ProjectContext>(opts =>
{
    opts.UseSqlServer(strCon);
});

//Injecting the service
//builder.Services.AddScoped<IRepo<int, Customer>, CustomerRepo>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddTransient <IRepo<int, Customer>, CustomerRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //to be added along swashbuckler
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
