namespace Core.Models;

public class Area
{
    public uint id { get; set; }
    public string name { get; set; }
    public List<Encounter> encounters { get; set; }
}
