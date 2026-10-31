using PokeApiClientNS;

namespace Core.Models;

public class PokemonEntry
{
    public int id { get; set; }
    public Specie pokemon_species { get; set; }

    public PokemonEntry(
        IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers entry)
    {
        id = entry.Id;
        pokemon_species = new Specie(entry.Pokemon_v2_pokemonspecy);
    }
}