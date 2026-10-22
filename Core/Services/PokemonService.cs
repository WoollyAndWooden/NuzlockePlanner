using Core.Models;

namespace Core.Services;

public class PokemonService : PokeApiService
{
    private readonly string pokemonUrl = $"{baseUrl}pokemon/";
    private readonly string abilityUrl = $"{baseUrl}ability/";
    private readonly string natureUrl = $"{baseUrl}nature/";
    private readonly string typeUrl = $"{baseUrl}type/";
    
    private List<Specie> pokemonSpecies = new List<Specie>();
    private List<Ability> pokemonAbilities = new List<Ability>();
    private List<Nature> pokemonNatures = new List<Nature>();
    private List<PokemonType> pokemonTypes = new List<PokemonType>();
    
    public PokemonService(HttpClient httpClient) : base(httpClient)
    {
        
    }

    public async Task<Specie?> GetPokemonAsync(int id)
    {
        var data = pokemonSpecies.FirstOrDefault(x => x.specieId == id);
        if (data is null)
        {
            data = await GetDataAsync<Specie>($"{pokemonUrl}{id}");
            pokemonSpecies.Add(data);
        }
        return data;
    }

    public async Task<Ability?> GetAbilityAsync(int id)
    {
        var data = pokemonAbilities.FirstOrDefault(x => x.abilityId == id);
        if (data is null)
        {
            data = await GetDataAsync<Ability>($"{abilityUrl}{id}");
            pokemonAbilities.Add(data);
        }
        return data;
    }
    public async Task<Nature?> GetNatureAsync(int id)
    {
        var data = await GetDataAsync<Nature>($"{pokemonUrl}{id}");
        return data;
    }

    public async Task<PokemonType?> GetPokemonTypeAsync(int id)
    {
        var data = await GetDataAsync<PokemonType>($"{abilityUrl}{id}");
        return data;
    }
}