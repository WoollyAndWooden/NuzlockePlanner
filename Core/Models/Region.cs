using Core.Services;
using PokeApiClientNS;

namespace Core.Models;

public class Region : NameIdResource
{
    public int versionGroupRegionId { get; set; }
    public VersionGroup versionGroup { get; set; }
    public List<Pokedex> pokedexes { get; set; }

    public Region(IGetGameDataForVersion_RegionData region, VersionGroup versionGroup)
    {
        versionGroupRegionId = region.Id;
        Id = region.Pokemon_v2_region.Id;
        Name = region.Pokemon_v2_region.Name;
        this.versionGroup = versionGroup;
    }
}
