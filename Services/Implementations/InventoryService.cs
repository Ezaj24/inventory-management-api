using InventoryManagement.Api.Data;
using InventoryManagement.Api.Dtos.Inventory;
using InventoryManagement.Api.Models;
using InventoryManagement.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryResponseDto> CreateAsync(InventoryCreateDto dto)
        {
            var inventory = new InventoryItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                LastUpdated = DateTime.UtcNow
            };

            _context.InventoryItems.Add(inventory);
            await _context.SaveChangesAsync();

            return MapToResponseDto(inventory);
        }

        public async Task<InventoryResponseDto?> GetByProductIdAsync(int productId)
        {
            var inventory = await _context.InventoryItems
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventory == null)
                return null;

            return MapToResponseDto(inventory);
        }

        public async Task<InventoryResponseDto?> UpdateQuantityAsync(int productId, int quantity)
        {
            var inventory = await _context.InventoryItems
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventory == null)
                return null;

            inventory.Quantity = quantity;
            inventory.LastUpdated = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return MapToResponseDto(inventory);
        }

        private static InventoryResponseDto MapToResponseDto(InventoryItem inventory)
        {
            return new InventoryResponseDto
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                Quantity = inventory.Quantity,
                LastUpdated = inventory.LastUpdated
            };
        }
    }
}
