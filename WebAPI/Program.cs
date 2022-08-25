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

builder.Services.AddDbContext<p3dbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P3DB")));
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
