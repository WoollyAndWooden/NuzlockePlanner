using System.Text.Json.Serialization;

namespace Core.Models;

public class Generation
{
    public uint id { get; set; }
    public string name { get; set; }
    public List<VersionGroup> version_groups { get; set; } = [];
}
