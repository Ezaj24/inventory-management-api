using InventoryManagement.Api.Dtos.Categories;
using InventoryManagement.Api.Models;

namespace InventoryManagement.Api.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateAsync(CreateCategoryDto dto);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);

    Task<bool> UpdateAsync(int id,CreateCategoryDto dto);

    Task<bool> DeleteAsync(int id);
}