using InventoryManagement.Api.Data;
using InventoryManagement.Api.Dtos.Products;
using InventoryManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

   
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == dto.CategoryId);

        if (category == null)
            return BadRequest("Invalid CategoryId");

        var product = new Product
        {
            Name = dto.Name,
            SKU = dto.SKU,
            CategoryId = dto.CategoryId
        };

        var inventoryItem = new InventoryItem
        {
            Product = product,
            Quantity = dto.Quantity,
            Price = dto.Price
        };

        _context.Products.Add(product);
        _context.InventoryItems.Add(inventoryItem);

        await _context.SaveChangesAsync();

        var response = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            CategoryName = category.Name,
            Quantity = inventoryItem.Quantity,
            Price = inventoryItem.Price
        };

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products
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

        return Ok(products);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.InventoryItem)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound();

        var response = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            CategoryName = product.Category.Name,
            Quantity = product.InventoryItem.Quantity,
            Price = product.InventoryItem.Price
        };

        return Ok(response);
    }
}
