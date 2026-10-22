namespace Core.Models;

public class Game
{
    public uint gameIdId { get; set; }
    public string name { get; set; }
    public uint? generation { get; set; }
    public List<Region> region { get; set; }
    public Pokedex pokedex { get; set; }
    public VersionGroup versionGroup { get; set; }
}
