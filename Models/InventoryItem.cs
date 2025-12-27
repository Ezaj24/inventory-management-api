namespace InventoryManagement.Api.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        
        public Product Product { get; set; } = null!;
    }
}
