namespace Core.Models;

public class VersionGroup
{
    public uint versionGroupId { get; set; }
    public string name { get; set; }
    public List<Game> games { get; set; }
}
