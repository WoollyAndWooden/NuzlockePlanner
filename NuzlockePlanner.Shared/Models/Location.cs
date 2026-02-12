namespace NuzlockePlanner.Shared.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;
    
    public ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
}
