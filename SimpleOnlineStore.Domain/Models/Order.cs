namespace SimpleOnlineStore.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public DateTime CreationDate { get; set; }
    public User Buyer { get; set; }

}
