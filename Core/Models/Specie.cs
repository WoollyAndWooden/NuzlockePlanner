using System.Text.Json.Serialization;

namespace Core.Models;

public class Specie
{
    public uint SpecieId { get; set; }
    public List<(Ability, bool)> AvailableAbilities = new List<(Ability, bool)>();
    public List<Game> GamesCatchable = new List<Game>();
    public Dictionary<Stat, uint> Bst = new Dictionary<Stat, uint>();
    public List<PokemonType> Types = new List<PokemonType>();
    public EvolutionLine EvolutionLine { get; set; }
    public PokemonCategory PokemonCategory { get; set; }
    public string Sprite  { get; set; }
}