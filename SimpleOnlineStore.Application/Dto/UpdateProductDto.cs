namespace Application.Dto;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public short Discount { get; set; }
    public decimal PriceWithDiscount { get; set; }
}