namespace BovIQ.Domain.Entities;

public class Herd
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public ApplicationUser Owner { get; set; } = null!;
    public ICollection<Cow> Cows { get; set; } = [];
}
