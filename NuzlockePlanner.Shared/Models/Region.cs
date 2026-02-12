namespace NuzlockePlanner.Shared.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // e.g., "Kanto"
    
    public ICollection<Location> Locations { get; set; } = new List<Location>();
}
