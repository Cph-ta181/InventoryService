using Microsoft.EntityFrameworkCore;
using InventorySerivce.Models;
using Microsoft.Extensions.DependencyInjection;
using InventorySerivce.Data;
using InventorySerivce.Services.RabbitMQ;
using InventorySerivce.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<InventorySerivceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventorySerivceContext") ?? throw new InvalidOperationException("Connection string 'InventorySerivceContext' not found.")));

// RabbitMQ
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
//builder.Services.AddHostedService<RabbitMQConsumer>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
