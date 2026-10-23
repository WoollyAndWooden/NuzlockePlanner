using System.Text.Json.Serialization;

namespace Core.Models;

public class Generation : NameIdResource
{
    public List<VersionGroup> version_groups { get; set; } = [];
    
    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is Generation full)
        {
            version_groups = full.version_groups;
        }
    }
}
