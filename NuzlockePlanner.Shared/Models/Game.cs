namespace NuzlockePlanner.Shared.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public bool SeperateDir { get; set; } = false;
    
    public int GenerationId { get; set; }
    public Generation Generation { get; set; } = null!;

    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;
}
