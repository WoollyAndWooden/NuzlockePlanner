using Core.Models;

namespace Core.Services;

public class PokemonService : PokeApiService
{
    private List<Specie> _pokemonSpecies = new List<Specie>();
    private List<Ability> _pokemonAbilities = new List<Ability>();
    private List<Nature> _pokemonNatures = new List<Nature>();
    private List<PokemonType> _pokemonTypes = new List<PokemonType>();
    private List<EvolutionLine> _pokemonEvolutionLines = new List<EvolutionLine>();
    private List<Stat> _pokemonStats = new List<Stat>();
    
    public PokemonService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<Specie?> GetPokemonAsync(int id)
    {
        var data = _pokemonSpecies.FirstOrDefault(x => x.SpecieId == id);
        if (data is null)
        {
            data = await GetDataAsync<Specie>($"{baseUrl}pokemon/{id}");
            if (data is not null)
            {
                _pokemonSpecies.Add(data);
            }
        }
        return data;
    }

    public async Task<Ability?> GetAbilityAsync(int id)
    {
        var data = _pokemonAbilities.FirstOrDefault(x => x.abilityId == id);
        if (data is null)
        {
            data = await GetDataAsync<Ability>($"{baseUrl}ability/{id}");
            if (data is not null)
            {
                _pokemonAbilities.Add(data);
            }
        }
        return data;
    }
    public async Task<Nature?> GetNatureAsync(int id)
    {
        var data = _pokemonNatures.FirstOrDefault(x => x.NatureId == id);
        if (data is null)
        {
            data = await GetDataAsync<Nature>($"{baseUrl}nature/{id}");
            if (data is not null)
            {
                _pokemonNatures.Add(data);
            }
        }
        return data;
    }

    public async Task<PokemonType?> GetPokemonTypeAsync(int id)
    {
        var data = _pokemonTypes.FirstOrDefault(x => x.typeId == id);
        if (data is null)
        {
            data = await GetDataAsync<PokemonType>($"{baseUrl}type/{id}");
            if (data is not null)
            {
                _pokemonTypes.Add(data);
            }
        }
        return data;
    }

    public async Task<EvolutionLine?> GetEvolutionLineAsync(int id)
    {
        var data = _pokemonEvolutionLines.FirstOrDefault(x => x.evolutionLineId == id);
        if (data is null)
        {
            data = await GetDataAsync<EvolutionLine>($"{baseUrl}evolution-chain/{id}");
            if (data is not null)
            {
                _pokemonEvolutionLines.Add(data);
            }
        }
        return data;
    }

    public async Task<Stat?> GetStatAsync(int id)
    {
        var data = _pokemonStats.FirstOrDefault(x => x.StatId == id);
        if (data is null)
        {
            data = await GetDataAsync<Stat>($"{baseUrl}stat/{id}");
            if (data is not null)
            {
                _pokemonStats.Add(data);
            }
        }
        return data;
    }
}
