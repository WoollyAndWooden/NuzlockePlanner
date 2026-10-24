using System.Text.Json.Serialization;

namespace Core.Models;

public class Specie : NameIdResource
{
    public int? order { get; set; }
    public int? gender_rate { get; set; }
    public int? capture_rate { get; set; }
    public int? base_happiness {get; set;}
    public bool? is_baby { get; set; }
    public bool? is_legendary { get; set; }
    public bool? is_mythical { get; set; }
    public List<(Ability, bool)> AvailableAbilities = new List<(Ability, bool)>();
    public List<Game> GamesCatchable = new List<Game>();
    public Dictionary<Stat, uint> Bst = new Dictionary<Stat, uint>();
    public List<PokemonType> Types = new List<PokemonType>();
    public Specie? evolves_from_specie { get; set; }
    public EvolutionLine? evolution_chain { get; set; }
}