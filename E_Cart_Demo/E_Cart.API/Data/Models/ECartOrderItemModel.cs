namespace ECart.API.Data.Models;

public class ECartOrderItemModel
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public ECartProductModel? Product { get; set; }
}
