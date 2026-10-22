using Core.Models;
using Core.Models.Dto;

namespace Core.Services;

public class GameDetailsService : PokeApiService
{
    private readonly string baseUrl = "https://pokeapi.co/api/v2/";

    private List<Generation> _generations = new List<Generation>();
    private int _generationCount = 0;
    private List<VersionGroup> _versionGroups = new List<VersionGroup>();
    private List<Game> _games = new List<Game>();
    private List<Region> _regions = new List<Region>();
    private List<Location> _locations = new List<Location>();
    private List<Area> _areas = new List<Area>();
    private List<Encounter> _encounters = new List<Encounter>();
    private List<EncounterMethod> _encounterMethods = new List<EncounterMethod>();

    public GameDetailsService(HttpClient httpClient) : base(httpClient)
    {
    }
    
    public async Task<List<Generation>> GetAllGenerationsAsync()
    {
        _generationCount = (_generationCount == 0) ? await GetGenerationCountAsync() : _generationCount;
        if (_generations.Count() < _generationCount)
        {
            for (int i = 1; i <= _generationCount; i++)
            {
                await GetGenerationAsync(i);
            }
        }
        return _generations;
    }
    public async Task<Generation> GetGenerationAsync(int id)
    {
        var data = _generations.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Generation>($"{baseUrl}generation/{id}");
            if (data is not null)
            {
                _generations.Add(data);
            }
        }
        return data;
    }
    public async Task<int> GetGenerationCountAsync()
    {
        if (_generationCount != 0)
            return _generationCount;
        var generations = await GetDataAsync<PokeApiListCountDto<Generation>>($"{baseUrl}generation?limit=1");
        return generations?.count ?? 0;
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
        var data = _games.FirstOrDefault(x => x.gameIdId == id);
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
        var data = _regions.FirstOrDefault(x => x.regionIdId == id);
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
        var data = _locations.FirstOrDefault(x => x.locationIdId == id);
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
        var data = _areas.FirstOrDefault(x => x.areaIdId == id);
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
        var data = _encounters.FirstOrDefault(x => x.encounterIdId == id);
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
        var data = _encounterMethods.FirstOrDefault(x => x.encounterMethodIdId == id);
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
