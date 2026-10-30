using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using PokeApiClientNS.State;

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
    public override string GetName()
    {
        string temp = Regex.Replace(name.Replace('-', ' '), @"\b\w", m => m.Value.ToUpper());
        string result = Regex.Replace(temp, @"\b\w+\s*$", m => m.Value.ToUpper());
        return result;
    }
}
