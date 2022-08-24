using Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interface;
using DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<p3dbContext>(options => options.UseSqlServer("Server=tcp:220620p3.database.windows.net,1433;Initial Catalog=p3db;Persist Security Info=False;User ID=p3admin;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<ICartDAO, CartRepo>();
builder.Services.AddScoped<CartServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
