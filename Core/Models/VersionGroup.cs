using PokeApiClientNS;

namespace Core.Models;

public class VersionGroup : NameIdResource
{
    public int? order { get; set; }
    
    public List<Game> versions { get; set; } = [];
    public List<Region> regions { get; set; } = [];
    public List<Pokedex> pokedexes { get; set; } = [];
    public Generation generation { get; set; }

    public VersionGroup(IGetInitialData_Generations_Pokemon_v2_versiongroups versiongroup)
    {
        Id = versiongroup.Id;
        Name = versiongroup.Name;
        order = versiongroup.Order;
        foreach (var version in versiongroup.Pokemon_v2_versions )
            versions.Add(new Game(version));
        
        foreach(var pokedex in versiongroup.Pokemon_v2_pokedexversiongroups)
            pokedexes.Add(new Pokedex(pokedex.Pokemon_v2_pokedex));
    }

    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is VersionGroup full)
        {
            order = full.order;
            versions = full.versions;
            regions = full.regions;
            pokedexes = full.pokedexes;
            generation = full.generation;
        }
    }
}
