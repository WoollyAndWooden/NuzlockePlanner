using System.Text.Json.Serialization;
using PokeApiClientNS;

namespace Core.Models;

public class Specie : NameIdResource
{
    public int? GenderRate { get; set; }
    public int? CaptureRate { get; set; }
    public int? BaseHappiness {get; set;}
    public bool? IsBaby { get; set; }
    public bool? IsLegendary { get; set; }
    public bool? IsMythical { get; set; }
    public List<Ability> AvailableAbilities = [];
    public List<Stat> Bst = [];
    public List<PokemonType> Types = [];
    public int? EvolvesFromSpecieId { get; set; }
    public EvolutionLine? EvolutionChain { get; set; }

    public Specie(
        IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy
            pokemon)
    {
        var pokemonDetails = pokemon.Pokemon_v2_pokemons.First();
        Id = pokemon.Id;
        Name = pokemon.Name;
        IsBaby = pokemon.Is_baby;
        IsLegendary = pokemon.Is_legendary;
        IsMythical = pokemon.Is_mythical;
        GenderRate = pokemon.Gender_rate;
        CaptureRate = pokemon.Capture_rate;
        BaseHappiness = pokemon.Base_happiness;
        EvolvesFromSpecieId = pokemon.Evolves_from_species_id ?? 0; 
        EvolutionChain = new EvolutionLine(pokemon.Pokemon_v2_evolutionchain);
        foreach (var ability in pokemonDetails.Pokemon_v2_pokemonabilitypasts)
            AvailableAbilities.Add(new Ability(ability));
        foreach (var ability in pokemonDetails.Pokemon_v2_pokemonabilities.Where(x =>
                     !AvailableAbilities.Select(a => a.slot).Contains(x.Slot)))
            AvailableAbilities.Add(new Ability(ability));
        foreach (var stat in pokemonDetails.Pokemon_v2_pokemonstats)
            Bst.Add(new Stat(stat));
        foreach (var type in pokemonDetails.Pokemon_v2_pokemontypepasts)
            Types.Add(new PokemonType(type));
        // TODO: 
        //foreach (var type in pokemonDetails.Pokemon_v2_pokemontypes.Where(x => !Types.Select(a => a.Slot).Contains(x.Slot)))
        //    Types.Add(new PokemonType(type));
    }

    public Specie(int? id, string name)
    {
        Id = id;
        Name = name;
    }
}