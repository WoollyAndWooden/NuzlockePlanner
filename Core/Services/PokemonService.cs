using Core.Models;

namespace Core.Services;

public class PokemonService : PokeApiService
{
    private readonly string _pokemonUrl = $"{baseUrl}pokemon/";
    private readonly string _abilityUrl = $"{baseUrl}ability/";
    private readonly string _natureUrl = $"{baseUrl}nature/";
    private readonly string _typeUrl = $"{baseUrl}type/";
    
    private List<Specie> _pokemonSpecies = new List<Specie>();
    private List<Ability> _pokemonAbilities = new List<Ability>();
    private List<Nature> _pokemonNatures = new List<Nature>();
    private List<PokemonType> _pokemonTypes = new List<PokemonType>();
    
    public PokemonService(HttpClient httpClient) : base(httpClient)
    {
        
    }

    public async Task<Specie?> GetPokemonAsync(int id)
    {
        var data = _pokemonSpecies.FirstOrDefault(x => x.specieId == id);
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
            _pokemonAbilities.Add(data);
        }
        return data;
    }
    public async Task<Nature?> GetNatureAsync(int id)
    {
        var data = _pokemonNatures.FirstOrDefault(x => x.natureId == id);
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
}
