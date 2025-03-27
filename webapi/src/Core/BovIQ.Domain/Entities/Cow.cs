namespace BovIQ.Domain.Entities;

public class Cow
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; } = default!;
    //public int HerdId { get; set; }
    //public Herd Herd { get; set; } = default!;
    public string? Name { get; set; } = string.Empty;
    public string EarTag { get; set; } = string.Empty;
    public DateTime FirstCalvingDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<MilkSession> MilkSessions { get; set; } = [];
}
