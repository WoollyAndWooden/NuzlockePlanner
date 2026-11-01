using PokeApiClientNS;

namespace Core.Models;

public class Stat : NameIdResource
{
    public Stat(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_pokemons_Pokemon_v2_pokemonstats stat)
    {
        Id = stat.Id;
        Name = stat.Pokemon_v2_stat.Name;
        BaseValue = stat.Base_stat;
    }
    public int BaseValue { get; set; }
}