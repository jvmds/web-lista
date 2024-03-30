namespace WebLista.Domain.Entities;

public class Item
{
    // Primary key
    public int ItemId { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }
    public bool Reserved { get; set; }
    public string? ReservationEmail { get; set; }
    
    // Foreign key
    public int GirftListId { get; set; }
    
    // Navigation properties
    public GiftList GiftList { get; set; }
    public ICollection<Store> Stores { get; set; } = new HashSet<Store>();
    
}