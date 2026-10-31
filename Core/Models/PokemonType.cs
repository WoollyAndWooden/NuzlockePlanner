using PokeApiClientNS;

namespace Core.Models;

public class PokemonType : NameIdResource
{
    public PokemonType(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_pokemons_Pokemon_v2_pokemontypepasts type)
    {
        Id = type.Pokemon_v2_type.Id;
        Name = type.Pokemon_v2_type.Name;
        Slot =  type.Slot;
    }

    public PokemonType(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_pokemons_Pokemon_v2_pokemontypes type)
    {
        Id = type.Pokemon_v2_type.Id;
        Name = type.Pokemon_v2_type.Name;
        Slot =  type.Slot;
    }

    public int Slot { get; set; }
}