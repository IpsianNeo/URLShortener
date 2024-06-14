namespace Presentation.Products;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public string? Sku { get; set; }
    public string? Currency { get; set; }
    public int Amount { get; set; }
}