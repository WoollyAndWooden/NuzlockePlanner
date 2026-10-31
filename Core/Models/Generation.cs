using System.Text.RegularExpressions;
using PokeApiClientNS;

namespace Core.Models;

public class Generation : NameIdResource
{
    public List<VersionGroup> version_groups { get; set; } = [];
    
    public Generation(IGetInitialData_Generations generation)
    {
        Id = generation.Id;
        Name = generation.Name;
        foreach (var versiongroup in generation.Pokemon_v2_versiongroups )
        {
            version_groups.Add(new VersionGroup(versiongroup));
        }
    }
    
    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is Generation full)
        {
            version_groups = full.version_groups;
        }
    }
    public override string GetName()
    {
        string temp = Regex.Replace(Name.Replace('-', ' '), @"\b\w", m => m.Value.ToUpper());
        string result = Regex.Replace(temp, @"\b\w+\s*$", m => m.Value.ToUpper());
        return result;
    }
}
