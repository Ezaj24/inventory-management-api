using InventoryManagement.Api.Dtos.Categories;
using InventoryManagement.Api.Models;

namespace InventoryManagement.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateAsync(CategoryCreateDto dto);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);

    Task<bool> UpdateAsync(int id,CategoryCreateDto dto);

    Task<bool> DeleteAsync(int id);
}