using Microsoft.AspNetCore.Identity;

namespace BovIQ.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreateAtUtc { get; set; }
    public DateTime UpdateAtUtc { get; set; }
    public ICollection<Herd> Herds { get; set; } = [];
}
