using Core.Models;

namespace Core.Services;

public class PokemonService : PokeApiService<Pokemon>
{
    private readonly string pokemonUrl = $"{baseUrl}pokemon/";
    public PokemonService(HttpClient httpClient) : base(httpClient)
    {
        
    }

    public async Task<Pokemon> GetPokemonAsync(int id)
    {
        var data = await GetDataAsync($"{pokemonUrl}{id}");
        return data;
    }
}