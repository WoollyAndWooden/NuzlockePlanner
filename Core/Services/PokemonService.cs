namespace Core.Services;

public class PokemonService : PokeApiService
{
    public PokemonService(HttpClient httpClient) : base(httpClient)
    {
        
    }

    public async Task<Pokemon> GetPokemonAsync(int id)
    {
        var data = await GetDataAsync($id);
    }
}