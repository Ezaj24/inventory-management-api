namespace InventoryManagement.Api.Dtos.Inventory
{
    public class InventoryResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
