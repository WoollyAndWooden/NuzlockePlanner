using PokeApiClientNS;

namespace Core.Models;

public class Pokedex : NameIdResource
{
    public int aggregateCount {get;set;}
    public List<PokemonEntry> pokemon_entries { get; set; }
    public Region region { get; set; }
    public List<VersionGroup> version_groups { get; set; } = [];

    public Pokedex(IGetInitialData_Generations_Pokemon_v2_versiongroups_Pokemon_v2_pokedexversiongroups_Pokemon_v2_pokedex pokedex)
    {
        id = pokedex.Id;
        name =  pokedex.Name;
        aggregateCount = pokedex.Pokemon_v2_pokemondexnumbers_aggregate.Aggregate.Count;

    }
    
    public async Task Fill(IGetGameDataForVersion_RegionData_Pokemon_v2_region_Pokemon_v2_pokedexes dex)
    {
        // TODO: Asynchronously fill up the pokedex. And for the love of God PLEASE go dor a run You fatass.
    }
    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is Pokedex full)
        {
            pokemon_entries = full.pokemon_entries;
            region = full.region;
            //version_groups = full.version_groups;
        }
    }
}