using System.Text.Json;
using Core.Models;
using Core.Models.Dto;
using PokeApiClientNS;
using PokeApiClientNS.State;

namespace Core.Services;

public class PokeApi
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/";

    private readonly List<Generation> _generations = [];
    private readonly List<VersionGroup> _versionGroups = [];
    private readonly List<Game> _games = [];
    private readonly List<Pokedex> _pokedexes = [];
    private readonly List<Region> _regions = [];
    private readonly List<Location> _locations = [];
    private readonly List<Area> _areas = new List<Area>();
    private readonly List<Encounter> _encounters = [];
    private readonly List<EncounterMethod> _encounterMethods = [];
    private readonly List<Specie> _pokemonSpecies = [];
    private readonly List<Ability> _pokemonAbilities = [];
    private readonly List<Nature> _pokemonNatures = [];
    private readonly List<PokemonType> _pokemonTypes = [];
    private readonly List<EvolutionLine> _pokemonEvolutionLines = [];
    private readonly List<Stat> _pokemonStats = [];
    
    private readonly HttpClient _httpClient;
    private readonly PokeApiClient _client;
    
    public PokeApi(PokeApiClient client)
    {
        _client = client;
    }

    public async Task GetInitialDataAsync()
    {
        var result = await _client.GetInitialData.ExecuteAsync();
        if (result.Data?.Generations is null)
            return;

        foreach (var generation in result.Data.Generations)
        {
            var tempGen = new Generation(generation);
            _generations.Add(tempGen);
            foreach (var versiongroup in tempGen.version_groups)
            {
                _versionGroups.Add(versiongroup);
                foreach(var pokedex in versiongroup.pokedexes)
                    _pokedexes.Add(pokedex);
                foreach (var version in versiongroup.versions)
                    _games.Add(version);
            }
        }
    }
    
    //public async Task GetGameDataForVersion
    
    public async Task<List<Generation>> GetAllGenerationsAsync()
    {
        await GetInitialDataAsync();

        return _generations;
    }
    
    public async Task<Generation?> GetGenerationAsync(int? id = null, string? name = null)
    {
        return _generations.FirstOrDefault(x => x.id == id || x.name == name);
    }
    
    public async Task<VersionGroup?> GetVersionGroupAsync(int? id = null, string? name = null)
    {
        return _versionGroups.FirstOrDefault(x => x.id == id || x.name == name);
    }

    public async Task<Game?> GetGameAsync(int? id = null, string? name = null)
    {
        return _games.FirstOrDefault(x => x.id == id || x.name == name);
    }
    
    // POKEDEX SECTION
    public async Task<Pokedex?> GetPokedexAsync(int? id = null, string? name = null)
    {
        return _pokedexes.FirstOrDefault(x => x.id == id || x.name == name);
    }

    public async Task<Region?> GetRegionAsync(int id)
    {
        var data = _regions.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Region>($"{BaseUrl}region/{id}");
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
            data = await GetDataAsync<Location>($"{BaseUrl}location/{id}");
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
            data = await GetDataAsync<Area>($"{BaseUrl}area/{id}");
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
            data = await GetDataAsync<Encounter>($"{BaseUrl}encounter/{id}");
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
            data = await GetDataAsync<EncounterMethod>($"{BaseUrl}encounter-method/{id}");
            if (data is not null)
            {
                _encounterMethods.Add(data);
            }
        }
        return data;
    }
    
    public async Task<Specie?> GetSpecieAsync(int? id = null, string? name = null)
    {
        return _pokemonSpecies.FirstOrDefault(x => x.id == id || x.name == name);
    }

    public async Task<Ability?> GetAbilityAsync(int id)
    {
        var data = _pokemonAbilities.FirstOrDefault(x => x.id == id);
        if (data is null)
        {
            data = await GetDataAsync<Ability>($"{BaseUrl}ability/{id}");
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
            data = await GetDataAsync<Nature>($"{BaseUrl}nature/{id}");
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
            data = await GetDataAsync<PokemonType>($"{BaseUrl}type/{id}");
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
            data = await GetDataAsync<EvolutionLine>($"{BaseUrl}evolution-chain/{id}");
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
            data = await GetDataAsync<Stat>($"{BaseUrl}stat/{id}");
            if (data is not null)
            {
                _pokemonStats.Add(data);
            }
        }
        return data;
    }

    private bool? IsFullyInitialized<T>(List<T> listToCheck, int? id, string? name) where T : NameIdResource
    {
        if (id is not null && listToCheck.Any(x => x.id == id))
            return true;
        if (name is not null && listToCheck.Any(x => x.name == name))
            return false;
        return null;
    }

    private void CacheIfNotInCache<T>(List<T> listToAdd, T data) where T : NameIdResource
    {
        if(IsFullyInitialized(listToAdd, data.id, data.name) is null)
            listToAdd.Add(data);
    }
    
    private string? GetIdentifier(int? id = null, string? name = null) =>  id?.ToString() ?? name;
    
    private async Task<T?> GetDataAsync<T>(string url) where T : class
    {
        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }
}
