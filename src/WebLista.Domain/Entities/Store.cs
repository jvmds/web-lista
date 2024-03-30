namespace WebLista.Domain.Entities;

public class Store
{
    // Primary key
    public int StoreId { get; set; }
    
    public string Name { get; set; }
    public string Link { get; set; }
    
    // Foreign key
    public int ItemId { get; set; }
    
    // Navigation properties
    public virtual Item Item { get; set; }
}