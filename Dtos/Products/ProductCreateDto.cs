namespace InventoryManagement.Api.Dtos.Products;

public class ProductCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
