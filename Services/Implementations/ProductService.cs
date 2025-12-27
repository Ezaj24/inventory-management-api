using InventoryManagement.Api.Data;
using InventoryManagement.Api.Dtos.Products;
using InventoryManagement.Api.Models;
using InventoryManagement.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            SKU = dto.SKU,
            CategoryId = dto.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // Create inventory entry automatically
        var inventory = new InventoryItem
        {
            ProductId = product.Id,
            Quantity = 0,
            Price = 0
        };

        _context.InventoryItems.Add(inventory);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<ProductResponseDto>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.InventoryItem)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                CategoryName = p.Category.Name,
                Quantity = p.InventoryItem.Quantity,
                Price = p.InventoryItem.Price
            })
            .ToListAsync();
    }


    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.InventoryItem)
            .Where(p => p.Id == id)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                CategoryName = p.Category.Name,
                Quantity = p.InventoryItem.Quantity,
                Price = p.InventoryItem.Price
            })
            .FirstOrDefaultAsync();
    }
}