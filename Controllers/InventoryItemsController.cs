using InventoryManagement.Api.Dtos.Inventory;
using InventoryManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryItemsController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryItemsController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory(InventoryCreateDto dto)
        {
            var result = await _inventoryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByProductId), new { productId = result.ProductId }, result);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var inventory = await _inventoryService.GetByProductIdAsync(productId);

            if (inventory == null)
                return NotFound("Inventory not found for this product.");

            return Ok(inventory);
        }

        [HttpPut("product/{productId}")]
        public async Task<IActionResult> UpdateQuantity(int productId, [FromBody] int quantity)
        {
            var updated = await _inventoryService.UpdateQuantityAsync(productId, quantity);

            if (updated == null)
                return NotFound("Inventory not found for this product.");

            return Ok(updated);
        }
    }
}
