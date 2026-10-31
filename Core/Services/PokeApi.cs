using Core.Models;
using PokeApiClientNS;

namespace Core.Services;

public class PokeApi(PokeApiClient client)
{

    private readonly List<Generation> _generations = [];
    private readonly List<VersionGroup> _versionGroups = [];
    private readonly List<Game> _games = [];
    private readonly List<Pokedex> _pokedexes = [];
    private readonly List<Region> _regions = [];
    private readonly List<Location> _locations = [];
    private readonly List<Area> _locationAreas = [];
    //private readonly List<Encounter> _encounters = [];
    private readonly List<EncounterMethod> _encounterMethods = [];
    private readonly List<Specie> _pokemonSpecies = [];
    private readonly List<Ability> _pokemonAbilities = [];
    private readonly List<Nature> _pokemonNatures = [];
    private readonly List<PokemonType> _pokemonTypes = [];
    private readonly List<EvolutionLine> _pokemonEvolutionLines = [];
    private readonly List<Stat> _pokemonStats = [];

    public async Task GetInitialDataAsync()
    {
        var result = await client.GetInitialData.ExecuteAsync();
        // TODO: Proper error handlings
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

    public async Task GetGameDataForVersion(string generationName, string versionGroupName, string versionName)
    {
        var result = await client.GetGameDataForVersion.ExecuteAsync(generationName, versionGroupName, versionName);
        // TODO: Proper Error handlings
        var encounterData = result.Data.EncountersData;
        var EncounterTasks = encounterData.Select(async item => await _processEncounters(item)).ToList();
        
        var regionData = result.Data.RegionData;
        var RegionTasks = regionData.Select(async item =>await _processRegions(item)).ToList();
        
        await Task.WhenAll(RegionTasks);
        foreach (var specie in _pokedexes.SelectMany(dex => dex.pokemon_entries?.Where(x =>
                     _pokemonSpecies.All(y => y.Name != x.pokemon_species?.Name))))
        {
            _pokemonSpecies.Add(specie.pokemon_species);
        }
        await Task.WhenAll(EncounterTasks);
    }

    private async Task _processEncounters(IGetGameDataForVersion_EncountersData data)
    {
        if(GetLocationAsync(data.Pokemon_v2_location.Id, data.Pokemon_v2_location.Name) is null)
            _locations.Add(new Location
            {
                Id = data.Pokemon_v2_location.Id, 
                Name = data.Pokemon_v2_location.Name
            });
        if (GetLocationArea(data.Id, data.Name) is null)
            _locationAreas.Add(new Area(data));
    }
    
    private async Task _processRegions(IGetGameDataForVersion_RegionData data)
    {
        var WIPRegion = new Region(data, GetVersionGroup(name: data.Pokemon_v2_versiongroup.Name));
        foreach (var regionDex in data.Pokemon_v2_region.Pokemon_v2_pokedexes)
        {
            var dexToFill = GetPokedex(regionDex.Id, regionDex.Name);
            await dexToFill.Fill(regionDex);
            WIPRegion.pokedexes.Add(dexToFill);
            foreach (var pokedex in WIPRegion.pokedexes)
                _pokedexes.Add(pokedex);
        }
    }
    
    
    public async Task<List<Generation>> GetAllGenerationsAsync()
    {
        await GetInitialDataAsync();

        return _generations;
    }
    
    public Generation? GetGeneration(int? id = null, string? name = null)
    {
        return _generations.FirstOrDefault(x => x.Id == id || x.Name == name);
    }
    
    public VersionGroup? GetVersionGroup(int? id = null, string? name = null)
    {
        return _versionGroups.FirstOrDefault(x => x.Id == id || x.Name == name);
    }

    public Game? GetGame(int? id = null, string? name = null)
    {
        return _games.FirstOrDefault(x => x.Id == id || x.Name == name);
    }
    
    // POKEDEX SECTION
    public Pokedex? GetPokedex(int? id = null, string? name = null)
    {
        return _pokedexes.FirstOrDefault(x => x.Id == id || x.Name == name);
    }

    public async Task<Region?> GetRegionAsync(int id)
    {
        var data = _regions.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<Region>($"{BaseUrl}region/{id}");
            if (data is not null)
            {
                _regions.Add(data);
            }
        }
        return data;
    }

    public async Task<Location?> GetLocationAsync(int? id = null, string? name = null)
    {
        return _locations.FirstOrDefault(x => x.Id == id || x.Name == name);
    }
    public Area? GetLocationArea(int? id = null, string? name = null)
    {
        return _locationAreas.FirstOrDefault(x => x.Id == id || x.Name == name);
    }

    /*public async Task<Area?> GetAreaAsync(int id)
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
    }*/
    
    public async Task<EncounterMethod?> GetEncounterMethodAsync(int id)
    {
        var data = _encounterMethods.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<EncounterMethod>($"{BaseUrl}encounter-method/{id}");
            if (data is not null)
            {
                _encounterMethods.Add(data);
            }
        }
        return data;
    }
    
    public async Task<Specie?> GetSpecieAsync(int? id = null, string? name = null)
    {
        return _pokemonSpecies.FirstOrDefault(x => x.Id == id || x.Name == name);
    }

    public async Task<Ability?> GetAbilityAsync(int id)
    {
        var data = _pokemonAbilities.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<Ability>($"{BaseUrl}ability/{id}");
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
            //data = await GetDataAsync<Nature>($"{BaseUrl}nature/{id}");
            if (data is not null)
            {
                _pokemonNatures.Add(data);
            }
        }
        return data;
    }

    public async Task<PokemonType?> GetPokemonTypeAsync(int id)
    {
        var data = _pokemonTypes.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<PokemonType>($"{BaseUrl}type/{id}");
            if (data is not null)
            {
                _pokemonTypes.Add(data);
            }
        }
        return data;
    }

    public async Task<EvolutionLine?> GetEvolutionLineAsync(int id)
    {
        var data = _pokemonEvolutionLines.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<EvolutionLine>($"{BaseUrl}evolution-chain/{id}");
            if (data is not null)
            {
                _pokemonEvolutionLines.Add(data);
            }
        }
        return data;
    }

    public async Task<Stat?> GetStatAsync(int id)
    {
        var data = _pokemonStats.FirstOrDefault(x => x.Id == id);
        if (data is null)
        {
            //data = await GetDataAsync<Stat>($"{BaseUrl}stat/{id}");
            if (data is not null)
            {
                _pokemonStats.Add(data);
            }
        }
        return data;
    }

    private bool? IsFullyInitialized<T>(List<T> listToCheck, int? id, string? name) where T : NameIdResource
    {
        if (id is not null && listToCheck.Any(x => x.Id == id))
            return true;
        if (name is not null && listToCheck.Any(x => x.Name == name))
            return false;
        return null;
    }

    private void CacheIfNotInCache<T>(List<T> listToAdd, T data) where T : NameIdResource
    {
        if(IsFullyInitialized(listToAdd, data.Id, data.Name) is null)
            listToAdd.Add(data);
    }
    
    private string? GetIdentifier(int? id = null, string? name = null) =>  id?.ToString() ?? name;
}
