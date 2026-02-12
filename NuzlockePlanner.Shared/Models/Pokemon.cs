namespace NuzlockePlanner.Shared.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public PokemonType Type1 { get; set; }
    public PokemonType? Type2 { get; set; }
    
    public ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
}
