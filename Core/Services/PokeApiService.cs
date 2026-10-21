namespace Core.Services;

public abstract class PokeApiService<T> where T : class
{
    private string baseUrl =  "https://pokeapi.co/api/v2/";
    protected readonly HttpClient httpClient;
    protected PokeApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<T> GetDataAsync(string url)
    {
        var response = await httpClient.GetAsync(baseUrl + url);
        return await response.Content.ReadAsStringAsync();
    }
}