namespace Core.Models;

public class VersionGroup
{
    public uint id { get; set; }
    public string name { get; set; }
    public List<Game> versions { get; set; }
}
