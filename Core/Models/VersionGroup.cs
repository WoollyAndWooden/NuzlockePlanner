namespace Core.Models;

public class VersionGroup : NameIdResource
{
    public int order { get; set; }
    public List<Game> versions { get; set; } = [];
    public List<Region> regions { get; set; } = [];
    public List<Pokedex> pokedexes { get; set; } = [];
    public Generation generation { get; set; }

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
