namespace WebLista.Domain.Entities;

public class GiftList
{
    // Primary key
    public int GiftLisId { get; set; }
    
    public string Name {get; set;}
    
    // Foreign key
    public int UserId { get; set; }
    
    // Navigation properties
    public virtual User User { get; set; }
    public virtual ICollection<Item> Items { get; private set; } = new HashSet<Item>();
    
    
    
}
