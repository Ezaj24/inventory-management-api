using InventoryManagement.Api.Dtos.Products;
namespace InventoryManagement.Api.Services.Interfaces;

public interface IProductService
{
    Task<Product> CreateAsync(ProductCreateDto dto);
    Task<List<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto?> GetByIdAsync(int id);

}