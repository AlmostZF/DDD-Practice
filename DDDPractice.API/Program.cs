using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Infrastructure;
using DDD_Practice.DDDPractice.Infrastructure.Repositories;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Repositories
builder.Services.AddScoped<IOrderReservationRepository, OrderReservationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

// Servicies
builder.Services.AddScoped<IUserService, UserService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

