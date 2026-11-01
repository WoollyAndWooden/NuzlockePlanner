using PokeApiClientNS;

namespace Core.Models;

public class EvolutionLine
{
    public EvolutionLine(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes_Pokemon_v2_pokemondexnumbers_Pokemon_v2_pokemonspecy_Pokemon_v2_evolutionchain? pokemonPokemonV2Evolutionchain)
    {
        Id = pokemonPokemonV2Evolutionchain.Id;
        foreach(var evolutions in pokemonPokemonV2Evolutionchain.Pokemon_v2_pokemonspecies)
            Evolutions.Add(new Specie(evolutions.Id, evolutions.Name));
    }

    public int Id { get; set; }
    public List<Specie> Evolutions = [];
}