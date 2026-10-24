using System.Text.Json;
using Core.Models;
using Core.Models.Dto;

namespace Core.Services;

public class PokeApi
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/";

    private readonly List<Generation> _generations = [];
    private int _generationCount;
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
    public PokeApi(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    // GENERATION SECTION
    public async Task<List<Generation>> GetAllGenerationsAsync()
    {
        _generationCount = (_generationCount == 0) ? await _getGenerationCountAsync() : _generationCount;
        if (_generations.Count() < _generationCount)
        {
            for (int i = 1; i <= _generationCount; i++)
            {
                await GetGenerationAsync(i);
            }
        }
        return _generations;
    }
    public async Task<Generation?> GetGenerationAsync(int? id = null, string? name = null)
    {
        var identifier = GetIdentifier(id, name);
        if (identifier is null)
            return null;
        bool? isFullyInitialized = IsFullyInitialized(_generations, id, name);
        var data = (isFullyInitialized == true) ? _generations.FirstOrDefault(x => x.id == id) : null;
        if (data is null)
        {
            data = await GetDataAsync<Generation>($"{BaseUrl}generation/{identifier}");
            if (isFullyInitialized == false)
                _generations.FirstOrDefault(x => x.id is null && x.name == data.name)?.FullInitialization(data);
            else if (data is not null)
            {
                _generations.Add(data);
                foreach(var versionGroup in data.version_groups)
                    CacheIfNotInCache(_versionGroups, versionGroup);
            }
        }
        return data;
    }
    private async Task<int> _getGenerationCountAsync()
    {
        if (_generationCount != 0)
            return _generationCount;
        var generations = await GetDataAsync<PokeApiListCountDto<Generation>>($"{BaseUrl}generation?limit=1");
        return generations?.count ?? 0;
    }
    
    // VERSIONGROUPSECTION
    public async Task<VersionGroup?> GetVersionGroupAsync(int? id = null, string? name = null)
    {
        var identifier = GetIdentifier(id, name);
        if(identifier is null)
            return null;
        bool? isFullyInitialized = IsFullyInitialized(_versionGroups, id, name);
        var data = (isFullyInitialized == true) ? _versionGroups.FirstOrDefault(x => x.id == id) : null;
        if (data is null)
        {
            data = await GetDataAsync<VersionGroup>($"{BaseUrl}version-group/{identifier}");
            if (data.name is not null)
            {
                data.generation = await GetGenerationAsync(name: data.generation.name ?? "");
                if (isFullyInitialized == false)
                    _versionGroups.FirstOrDefault(x => x.id is null && x.name == data.name)?.FullInitialization(data);
                else
                    _versionGroups.Add(data);
                foreach(var version in data.versions)
                    CacheIfNotInCache(_games, version);
                foreach(var region in data.regions)
                    CacheIfNotInCache(_regions, region);
                foreach(var pokedex in data.pokedexes)
                    CacheIfNotInCache(_pokedexes, pokedex);
                
            }
        }
        return data;
    }
    
    // GAME VERSION SECTION
    public async Task<Game?> GetGameAsync(int? id = null, string? name = null)
    {
        var identifier = GetIdentifier(id, name);
        if(identifier is null)
            return null;
        bool? isFullyInitialized = IsFullyInitialized(_games, id, name);
        var data = (isFullyInitialized == true) ? _games.FirstOrDefault(x => x.id == id) : null;;
        if (data is null)
        {
            data = await GetDataAsync<Game>($"{BaseUrl}version/{identifier}");
            if (data.name is not null)
            {
                data.version_group = await GetVersionGroupAsync(name: data.version_group.name);

                if (isFullyInitialized == false)
                    _games.FirstOrDefault(x => x.id is null && x.name == data.name)?.FullInitialization(data);
                else
                    _games.Add(data);
            }
        }
        return data;
    }
    
    // POKEDEX SECTION
    public async Task<Pokedex?> GetPokedexAsync(int? id = null, string? name = null)
    {
        var identifier = GetIdentifier(id, name);
        if(identifier is null)
            return null;
        bool? isFullyInitialized = IsFullyInitialized(_pokedexes, id, name);
        var data = (isFullyInitialized == true) ? _pokedexes.FirstOrDefault(x => x.id == id) : null;
        if (data is null)
        {
            data = await GetDataAsync<Pokedex>($"{BaseUrl}pokedex/{identifier}");
            if (data.name is not null)
            {
                //data.version_group = await GetVersionGroupAsync(name: data.version_group.name);

                if (isFullyInitialized == false)
                    _pokedexes.FirstOrDefault(x => x.id is null && x.name == data.name)?.FullInitialization(data);
                else
                    _pokedexes.Add(data);
            }
        }
        return data;
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
    
    public async Task<Specie?> GetPokemonAsync(int id)
    {
        var data = _pokemonSpecies.FirstOrDefault(x => x.SpecieId == id);
        if (data is null)
        {
            data = await GetDataAsync<Specie>($"{BaseUrl}pokemon/{id}");
            if (data is not null)
            {
                _pokemonSpecies.Add(data);
            }
        }
        return data;
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
