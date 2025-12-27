using InventoryManagement.Api.Data;
using InventoryManagement.Api.Middlewares;
using InventoryManagement.Api.Services.Implementations;
using InventoryManagement.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();


app.MapControllers();

app.Run();
