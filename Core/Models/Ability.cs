using PokeApiClientNS;

namespace Core.Models;

public class Ability : NameIdResource
{
    public int slot { get; set; }

    public Ability(
        IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_pokemons_Pokemon_v2_pokemonabilitypasts
            ability)
    {
        Id = ability.Pokemon_v2_ability.Id;
        Name = ability.Pokemon_v2_ability.Name;
        slot = ability.Slot;

    }

    public Ability(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_pokemons_Pokemon_v2_pokemonabilities ability)
    {
        Id = ability.Pokemon_v2_ability.Id;
        Name = ability.Pokemon_v2_ability.Name;
        slot = ability.Slot;
    }
}