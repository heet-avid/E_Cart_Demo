namespace ECart.API.Data.Models;

public class ECartOrderModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ECartOrderItemModel> OrderItems { get; set; }
}
