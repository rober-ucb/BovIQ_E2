namespace BovIQ.Domain.Entities;

public class Breed
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Cow> Cows { get; set; } = [];
}
