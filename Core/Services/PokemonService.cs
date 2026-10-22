using Core.Models;

namespace Core.Services;

public class PokemonService : PokeApiService
{
    private readonly string _pokemonUrl = $"{baseUrl}pokemon/";
    private readonly string _abilityUrl = $"{baseUrl}ability/";
    private readonly string _natureUrl = $"{baseUrl}nature/";
    private readonly string _typeUrl = $"{baseUrl}type/";
    private readonly string _evolutionLineUrl = $"{baseUrl}evolution-chain/";
    private readonly string _statUrl = $"{baseUrl}stat/";
    
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
            data = await GetDataAsync<Specie>($"{_pokemonUrl}{id}");
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
            data = await GetDataAsync<Ability>($"{_abilityUrl}{id}");
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
            data = await GetDataAsync<Nature>($"{_natureUrl}{id}");
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
            data = await GetDataAsync<PokemonType>($"{_typeUrl}{id}");
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
            data = await GetDataAsync<EvolutionLine>($"{_evolutionLineUrl}{id}");
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
            data = await GetDataAsync<Stat>($"{_statUrl}{id}");
            if (data is not null)
            {
                _pokemonStats.Add(data);
            }
        }
        return data;
    }
}
