namespace Core.Models;

public class Nature
{
    public uint NatureId { get; set; }
    public string Name { get; set; }
    public Stat DecreasedStat { get; set; }
    public Stat IncreasedStat { get; set; }
}