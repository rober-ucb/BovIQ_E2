namespace BovIQ.Domain.Entities;

public class MilkSession
{
    public int Id {  get; set; }
    public int CowId { get; set; }
    public Cow Cow { get; set; } = null!;
    public MilkingTime MilkingTime { get; set; }
    public double MilkVolume { get; set; }
    public string? Notes { get; set; }
}
public enum MilkingTime
{
    Morning,
    Evening
}
