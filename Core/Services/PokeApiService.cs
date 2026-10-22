using System.Text.Json;

namespace Core.Services;

public abstract class PokeApiService
{
    protected static readonly string baseUrl =  "https://pokeapi.co/api/v2/";
    protected readonly HttpClient httpClient;
    protected PokeApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    protected async Task<T?> GetDataAsync<T>(string url) where T : class
    {
        var response = await httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }
}