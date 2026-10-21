namespace Core.Models;

public class Specie
{
    public uint specieId { get; set; }
    public List<(Ability, bool)> availableAbilities { get; set; }
    public List<Game> gamesCatchable { get; set; }
    public List<Stat> BST { get; set; }
    public List<PokemonType>  types { get; set; }
    public EvolutionLine evolutionLine { get; set; }
    public PokemonCategory pokemonCategory { get; set; }
}