namespace NuzlockePlanner.Shared.Models;

public class Generation
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string GenDir { get; set; } = string.Empty; // e.g., "GenI"
    public ICollection<Game> Games { get; set; } = new List<Game>();
}
