using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebLista.Domain.Entities;

public class User
{
    // Primary key
    public int UserId { get; set; }
    
    public string IdentityUserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    // Navigation properties
    public ICollection<GiftList> GiftLists { get; private set; } = new HashSet<GiftList>();
}