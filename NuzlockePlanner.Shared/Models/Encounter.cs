namespace NuzlockePlanner.Shared.Models;

public class Encounter
{
    public int Id { get; set; }
    
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;
    
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;

    public int? ChancePercentage { get; set; }
    public EncounterType Method { get; set; }
    
    public int MinLevel { get; set; }
    public int MaxLevel { get; set; }
}
