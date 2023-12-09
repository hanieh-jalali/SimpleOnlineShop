using System.ComponentModel.DataAnnotations;

namespace SimpleOnlineStore.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public short Discount { get; set; }

    public void Validate()
    {
        if (Title.Length > 40) 
            throw new ArgumentException("Title must be less than 40 char");
    }
}       