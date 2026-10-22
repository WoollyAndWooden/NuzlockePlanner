namespace Core.Services;

public class GameDetailsService
{
    
}using Core.Models;

namespace Core.Services;

public class GameDetailsService : PokeApiService
{
    private readonly string baseUrl = "https://pokeapi.co/api/v2/";
    
    private List<VersionGroup> _versionGroups = new List<VersionGroup>();
    private List<Game> _games = new List<Game>();
    private List<Region> _regions = new List<Region>();
    private List<Location> _locations = new List<Location>();
    private List<Area> _areas = new List<Area>();
    private List<Encounter> _encounters = new List<Encounter>();
    private List<EncounterMethod> _encounterMethods = new List<EncounterMethod>();

    public GameDetailsService(HttpClient httpClient) : base(httpClient)
    {
        baseUrl = "https://pokeapi.co/api/v2/";
    }

    private async Task<T?> GetDataAsync<T>(string url) where T : class
    {
        var data = await base.GetDataAsync<T>(url);
        return data;
    }

    public async Task<VersionGroup?> GetVersionGroupAsync(int id)
    {
        var data = _versionGroups.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<VersionGroup>($"{baseUrl}version-group/{id}");
            if (data is not null)
            {
                _versionGroups.Add(data);
            }
        }
        return data;
    }

    public async Task<Game?> GetGameAsync(int id)
    {
        var data = _games.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Game>($"{baseUrl}game/{id}");
            if (data is not null)
            {
                _games.Add(data);
            }
        }
        return data;
    }

    public async Task<Region?> GetRegionAsync(int id)
    {
        var data = _regions.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Region>($"{baseUrl}region/{id}");
            if (data is not null)
            {
                _regions.Add(data);
            }
        }
        return data;
    }

    public async Task<Location?> GetLocationAsync(int id)
    {
        var data = _locations.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Location>($"{baseUrl}location/{id}");
            if (data is not null)
            {
                _locations.Add(data);
            }
        }
        return data;
    }

    public async Task<Area?> GetAreaAsync(int id)
    {
        var data = _areas.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Area>($"{baseUrl}area/{id}");
            if (data is not null)
            {
                _areas.Add(data);
            }
        }
        return data;
    }

    public async Task<Encounter?> GetEncounterAsync(int id)
    {
        var data = _encounters.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Encounter>($"{baseUrl}encounter/{id}");
            if (data is not null)
            {
                _encounters.Add(data);
            }
        }
        return data;
    }

    public async Task<EncounterMethod?> GetEncounterMethodAsync(int id)
    {
        var data = _encounterMethods.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<EncounterMethod>($"{baseUrl}encounter-method/{id}");
            if (data is not null)
            {
                _encounterMethods.Add(data);
            }
        }
        return data;
    }
}
