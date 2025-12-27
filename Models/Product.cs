namespace InventoryManagement.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        
        public int CategoryId { get; set; }

        
        public Category Category { get; set; } = null!;

        
        public InventoryItem InventoryItem { get; set; } = null!;
    }
}
