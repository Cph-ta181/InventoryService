using Microsoft.EntityFrameworkCore;
using InventorySerivce.Models;
using Microsoft.Extensions.DependencyInjection;
using InventorySerivce.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InventorySerivceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventorySerivceContext") ?? throw new InvalidOperationException("Connection string 'InventorySerivceContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext to use SQL Server
//builder.Services.AddDbContext<ItemContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
