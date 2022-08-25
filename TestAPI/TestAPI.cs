using DataAccess.Entities;
using CustomExceptions;
using Models;
using System.Data.SqlClient;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;
using Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<p3dbContext>(options => options.UseSqlServer("Server=tcp:220620p3.database.windows.net,1433;Initial Catalog=p3db;Persist Security Info=False;User ID=p3admin;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<IProductsDAO, ProductsRepo>();

builder.Services.AddScoped<ProductServices>();

builder.Services.AddScoped<ProductController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Products/GetAll", (ProductController ProdControl) => 
{
	return ProdControl.GetAllProducts();
});

app.MapGet("/Products/GetByPriceRange", (int priceMin, int priceMax, ProductController ProdControl) => 
{
	return ProdControl.GetProductsByPriceRange(priceMin, priceMax);
});

app.MapGet("/Products/GetByCategory", (string category, ProductController ProdControl) => 
{
	return ProdControl.GetProductsByCategory(category);
});
app.Run();
