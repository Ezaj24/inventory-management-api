using InventoryManagement.Api.Dtos.Inventory;

namespace InventoryManagement.Api.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryResponseDto> CreateAsync(InventoryCreateDto dto);
        Task<InventoryResponseDto?> GetByProductIdAsync(int productId);
        Task<InventoryResponseDto?> UpdateQuantityAsync(int productId, int quantity);
    }
}
