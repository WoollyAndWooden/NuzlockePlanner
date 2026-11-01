using PokeApiClientNS;

namespace Core.Models;

public class Game : NameIdResource
{
    public VersionGroup version_group { get; set; }
    
    public Game(IGetInitialData_Generations_Pokemon_v2_versiongroups_Pokemon_v2_versions version)
    {
        Id = version.Id;
        Name = version.Name;
    }
}
