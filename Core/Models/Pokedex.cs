namespace Core.Models;

public class Pokedex : NameIdResource
{
    public bool is_main_series {get; set;} = false;
    public List<PokemonEntry> pokemon_entries { get; set; }
    public Region region { get; set; }
    public List<VersionGroup> version_groups { get; set; } = [];
    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is Pokedex full)
        {
            is_main_series = full.is_main_series;
            pokemon_entries = full.pokemon_entries;
            region = full.region;
            //version_groups = full.version_groups;
        }
    }
}